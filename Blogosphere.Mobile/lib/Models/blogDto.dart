// blog_dto.dart
class BlogDto {
  final int id;
  final String title;
  final String content;
  final String summary;
  final String smallImageUrl;
  final String largeImageUrl;
  final int userId;

  BlogDto({
    required this.id,
    required this.title,
    required this.content,
    required this.summary,
    required this.smallImageUrl,
    required this.largeImageUrl,
    required this.userId,
  });

  factory BlogDto.fromJson(Map<String, dynamic> json) {
    return BlogDto(
      id: json['id'],
      title: json['title'],
      content: json['content'],
      summary: json['summary'],
      smallImageUrl: json['smallImageUrl'],
      largeImageUrl: json['largeImageUrl'],
      userId: json['userId'],
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'id': id,
      'title': title,
      'content': content,
      'summary': summary,
      'smallImageUrl': smallImageUrl,
      'largeImageUrl': largeImageUrl,
      'userId': userId,
    };
  }
}
