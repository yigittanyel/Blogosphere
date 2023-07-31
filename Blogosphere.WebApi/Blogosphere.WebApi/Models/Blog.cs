namespace Blogosphere.WebApi.Models;

public class Blog
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string SmallImageUrl { get; set; } = string.Empty;
    public string LargeImageUrl { get; set; } = string.Empty;
    public int? UserId { get; set; }
    public virtual User User { get; set; }

    public Blog(int id, string title, string content,string summary, string smallImageUrl, string largeImageUrl, int? userId)
    {
        Id = id;
        Title = title;
        Content = content;
        Summary = summary;
        SmallImageUrl = smallImageUrl;
        LargeImageUrl = largeImageUrl;
        UserId = userId;
    }

    public Blog(string title, string content,string summary, string smallImageUrl, string largeImageUrl, int? userId)
    {
        Title = title;
        Content = content;
        Summary = summary;
        SmallImageUrl = smallImageUrl;
        LargeImageUrl = largeImageUrl;
        UserId = userId;
    }
    public Blog()
    {
    }
}

