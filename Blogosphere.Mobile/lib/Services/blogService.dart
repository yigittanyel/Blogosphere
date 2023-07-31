import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/blogDto.dart';
import '../Models/createBlogDto.dart';
import '../Models/createBlogWithoutLargeDto.dart';
import '../Models/updateBlogDto.dart';

class BlogService {
  final String baseUrl;

  BlogService(this.baseUrl);

  Future<List<BlogDto>> getBlogs() async {
    final response = await http.get(Uri.parse('$baseUrl/api/Blog/GetBlogs'));
    if (response.statusCode == 200) {
      final data = json.decode(response.body) as List;
      return data.map((json) => BlogDto.fromJson(json)).toList();
    } else {
      throw Exception('Failed to load blogs');
    }
  }

  Future<List<BlogDto>> getBlog(int id) async {
    final response = await http.get(Uri.parse('$baseUrl/api/Blog/GetBlog/$id'));
    if (response.statusCode == 200) {
      List<dynamic> jsonResponse = jsonDecode(response.body);
      return jsonResponse.map((json) => BlogDto.fromJson(json)).toList();
    } else if (response.statusCode == 404) {
      throw Exception('Blog not found');
    } else {
      throw Exception('Failed to load blog');
    }
  }

  Future<void> putBlog(int id, UpdateBlogDto updateBlogDto) async {
    final response = await http.put(
      Uri.parse('$baseUrl/api/Blog/PutBlog/$id'),
      headers: {'Content-Type': 'application/json'},
      body: json.encode(updateBlogDto.toJson()),
    );

    if (response.statusCode != 204) {
      throw Exception('Failed to update blog');
    }
  }

  Future<BlogDto> postBlog(CreateBlogDto createBlogDto) async {
    final response = await http.post(
      Uri.parse('$baseUrl/api/Blog/PostBlogWithoutLargePic'),
      headers: {'Content-Type': 'application/json'},
      body: json.encode(createBlogDto.toJson()),
    );

    if (response.statusCode == 201) {
      final data = json.decode(response.body);
      return BlogDto.fromJson(data);
    } else {
      throw Exception('Failed to create blog');
    }
  }

  Future<BlogDto> postBlogWithoutLargePic(
      CreateBlogDtoWithoutLarge createBlogDto) async {
    final response = await http.post(
      Uri.parse('$baseUrl/api/Blog/PostBlogWithoutLargePic'),
      headers: {'Content-Type': 'application/json'},
      body: json.encode(createBlogDto.toJson()),
    );

    if (response.statusCode == 201) {
      final data = json.decode(response.body);
      return BlogDto.fromJson(data);
    } else {
      throw Exception('Failed to create blog without large picture');
    }
  }

  Future<void> deleteBlog(int id) async {
    final response =
        await http.delete(Uri.parse('$baseUrl/api/Blog/DeleteBlog/$id'));

    if (response.statusCode != 204) {
      throw Exception('Failed to delete blog');
    }
  }
}
