// create_blog_dto.dart
class CreateBlogDto {
  final String title;
  final String content;
  final String summary;
  final String smallImageUrl;
  final int userId;

  CreateBlogDto({
    required this.title,
    required this.content,
    required this.summary,
    required this.smallImageUrl,
    required this.userId,
  });

  Map<String, dynamic> toJson() {
    return {
      'Title': title,
      'Content': content,
      'Summary': summary,
      'SmallImageUrl': smallImageUrl,
      'UserId': userId,
    };
  }
}
