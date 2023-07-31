namespace Blogosphere.WebApi.DTOs;


public record BlogDto(int Id, string Title, string Content, string Summary,string SmallImageUrl, string LargeImageUrl, int UserId)
{
    public BlogDto() : this(default, default, default, default, default, default,default)
    {
    }
}
public record CreateBlogDto(string Title, string Content, string Summary,string SmallImageUrl, string LargeImageUrl, int UserId);
public record CreateBlogDtoWithoutLarge(string Title, string Content, string Summary,string SmallImageUrl,int UserId);

public record UpdateBlogDto(int Id, string Title, string Content,string Summary, string SmallImageUrl, string LargeImageUrl, int UserId);

