// update_blog_dto.dart
class UpdateBlogDto {
  final int id;
  final String title;
  final String content;
  final String summary;
  final String smallImageUrl;
  final String largeImageUrl;
  final int userId;

  UpdateBlogDto({
    required this.id,
    required this.title,
    required this.content,
    required this.summary,
    required this.smallImageUrl,
    required this.largeImageUrl,
    required this.userId,
  });

  Map<String, dynamic> toJson() {
    return {
      'Id': id,
      'Title': title,
      'Content': content,
      'Summary': summary,
      'SmallImageUrl': smallImageUrl,
      'LargeImageUrl': largeImageUrl,
      'UserId': userId,
    };
  }
}
