import 'package:flutter/material.dart';
import 'Models/blogDto.dart';
import 'Models/createBlogDto.dart';
import 'Models/updateBlogDto.dart';
import 'Services/blogService.dart';

void main() {
  runApp(BlogPage());
}

class BlogPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Blog App',
      home: BlogScreen(),
    );
  }
}

class BlogScreen extends StatefulWidget {
  @override
  _BlogScreenState createState() => _BlogScreenState();
}

class _BlogScreenState extends State<BlogScreen> {
  final BlogService blogService = BlogService('https://localhost:44363');
  final _formKey = GlobalKey<FormState>();
  late TextEditingController _titleController;
  late TextEditingController _contentController;
  late TextEditingController _summaryController;

  @override
  void initState() {
    super.initState();
    _titleController = TextEditingController();
    _contentController = TextEditingController();
    _summaryController = TextEditingController();
  }

  @override
  void dispose() {
    _titleController.dispose();
    _contentController.dispose();
    _summaryController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Blogosphere'),
      ),
      body: FutureBuilder<List<BlogDto>>(
        future: blogService.getBlogs(),
        builder: (context, snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return const Center(
              child: CircularProgressIndicator(),
            );
          } else if (snapshot.hasError) {
            return Center(
              child: Text('Error: ${snapshot.error}'),
            );
          } else {
            final blogs = snapshot.data!;
            return GridView.builder(
              gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                crossAxisCount: 2,
              ),
              itemCount: blogs.length,
              itemBuilder: (context, index) {
                final blog = blogs[index];
                return _buildBlogItem(blog);
              },
            );
          }
        },
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () => _showAddNewBlogForm(),
        child: Icon(Icons.add),
      ),
    );
  }

  Widget _buildBlogItem(BlogDto blog) {
    return Card(
      child: InkWell(
        onTap: () => _showBlogDetail(blog),
        onLongPress: () => _showBlogOptions(blog),
        child: Column(
          children: [
            Expanded(
              child: Image.network(
                blog.smallImageUrl,
                fit: BoxFit.cover,
              ),
            ),
            ListTile(
              title: Text(blog.title),
              subtitle: Text(blog.summary),
            ),
          ],
        ),
      ),
    );
  }

  void _showBlogDetail(BlogDto blog) {
    _titleController.text = blog.title;
    _contentController.text = blog.content;
    _summaryController.text = blog.summary;

    showModalBottomSheet(
      context: context,
      builder: (BuildContext context) {
        return SingleChildScrollView(
          child: Container(
            padding: EdgeInsets.all(16),
            child: Form(
              key: _formKey,
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.stretch,
                children: [
                  TextFormField(
                    controller: _titleController,
                    decoration: InputDecoration(labelText: 'Title'),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Please enter a title';
                      }
                      return null;
                    },
                  ),
                  TextFormField(
                    controller: _contentController,
                    decoration: InputDecoration(labelText: 'Content'),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Please enter content';
                      }
                      return null;
                    },
                  ),
                  TextFormField(
                    controller: _summaryController,
                    decoration: InputDecoration(labelText: 'Summary'),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Please enter a summary';
                      }
                      return null;
                    },
                  ),
                  SizedBox(height: 16),
                  ElevatedButton(
                    onPressed: () => _editBlog(blog),
                    child: Text('Edit'),
                  )
                ],
              ),
            ),
          ),
        );
      },
    );
  }

  void _showBlogOptions(BlogDto blog) {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text('Delete Blog'),
          content: Text('Are you sure you want to delete this blog?'),
          actions: [
            TextButton(
              onPressed: () {
                Navigator.pop(context);
              },
              child: Text('No'),
            ),
            TextButton(
              onPressed: () async {
                try {
                  await blogService.deleteBlog(blog.id);
                  Navigator.pop(context); // Close the dialog
                  _showSnackbar('Blog successfully deleted', Colors.red);
                  setState(() {}); // Refresh the blog list
                } catch (e) {
                  print('Delete error: $e');
                  _showSnackbar('Failed to delete blog', Colors.red);
                }
              },
              child: Text('Yes'),
            ),
          ],
        );
      },
    );
  }

  void _editBlog(BlogDto blog) async {
    if (_formKey.currentState!.validate()) {
      _formKey.currentState!.save();

      final updatedBlog = UpdateBlogDto(
        id: blog.id,
        title: _titleController.text,
        content: _contentController.text,
        summary: _summaryController.text,
        smallImageUrl: blog.smallImageUrl,
        largeImageUrl: blog.largeImageUrl,
        userId: blog.userId,
      );

      try {
        await blogService.putBlog(blog.id, updatedBlog);
        Navigator.pop(context); // Close the edit form modal
        _showSnackbar('Blog successfully updated', Colors.green);
        setState(() {}); // Refresh the blog list
      } catch (e) {
        print('Update error: $e');
        _showSnackbar('Failed to update blog', Colors.red);
      }
    }
  }

  void _showSnackbar(String message, Color backgroundColor) {
    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(
        content: Text(message),
        backgroundColor: backgroundColor,
        duration: Duration(seconds: 2),
      ),
    );
  }

  void _showAddNewBlogForm() {
    _titleController.text = '';
    _contentController.text = '';
    _summaryController.text = '';

    showModalBottomSheet(
      context: context,
      builder: (BuildContext context) {
        return SingleChildScrollView(
          child: Container(
            padding: EdgeInsets.all(16),
            child: Form(
              key: _formKey,
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.stretch,
                children: [
                  TextFormField(
                    controller: _titleController,
                    decoration: InputDecoration(labelText: 'Title'),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Please enter a title';
                      }
                      return null;
                    },
                  ),
                  TextFormField(
                    controller: _contentController,
                    decoration: InputDecoration(labelText: 'Content'),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Please enter content';
                      }
                      return null;
                    },
                  ),
                  TextFormField(
                    controller: _summaryController,
                    decoration: InputDecoration(labelText: 'Summary'),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Please enter a summary';
                      }
                      return null;
                    },
                  ),
                  SizedBox(height: 16),
                  ElevatedButton(
                    onPressed: () => _addNewBlog(),
                    child: Text('Add New Blog'),
                  ),
                ],
              ),
            ),
          ),
        );
      },
    );
  }

  void _addNewBlog() async {
    if (_formKey.currentState!.validate()) {
      _formKey.currentState!.save();

      final newBlog = CreateBlogDto(
        title: _titleController.text,
        content: _contentController.text,
        summary: _summaryController.text,
        smallImageUrl: '', // Set the small image URL if necessary
        userId: 1, // Set the user ID if necessary
      );

      try {
        await blogService.postBlog(newBlog);
        Navigator.pop(context); // Close the add new blog form modal
        _showSnackbar('Blog successfully added', Colors.green);
        setState(() {}); // Refresh the blog list
      } catch (e) {
        print('Add new blog error: $e');
        _showSnackbar('Failed to add new blog', Colors.red);
      }
    }
  }
}
