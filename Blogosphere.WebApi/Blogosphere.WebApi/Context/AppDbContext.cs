using Blogosphere.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Blogosphere.WebApi.Context;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Blog> Blogs { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Blogs)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasData(new List<User>()
            {
                new User(id: 1, username: "admin", password: "admin", firstName: "Admin", lastName: "Admin"),
                new User(id: 2, username: "user", password: "user", firstName: "User", lastName: "User"),
                new User(id: 3, username: "user2", password: "user2", firstName: "User2", lastName: "User2"),
                new User(id: 4, username: "user3", password: "user3", firstName: "User3", lastName: "User3"),
                new User(id: 5, username: "user4", password: "user4", firstName: "User4", lastName: "User4"),
                new User(id: 6, username: "user5", password: "user5", firstName: "User5", lastName: "User5"),
                new User(id: 7, username: "user6", password: "user6", firstName: "User6", lastName: "User6"),
            });

        modelBuilder.Entity<Blog>()
            .HasData(new List<Blog>()
            {
                new Blog(id: 1, title: "Blog 1", content: "Blog 1 Description", summary:"summary",smallImageUrl: "https://via.placeholder.com/150", largeImageUrl: "https://via.placeholder.com/350", userId: 1),
                new Blog(id: 2, title: "Blog 2", content: "Blog 2 Description",summary:"summary", smallImageUrl: "https://via.placeholder.com/150", largeImageUrl: "https://via.placeholder.com/350", userId: 1),
                new Blog(id: 3, title: "Blog 3", content: "Blog 3 Description",summary:"summary", smallImageUrl: "https://via.placeholder.com/150", largeImageUrl: "https://via.placeholder.com/350", userId: 2),
                new Blog(id: 4, title: "Blog 4", content: "Blog 4 Description",summary:"summary", smallImageUrl: "https://via.placeholder.com/150", largeImageUrl: "https://via.placeholder.com/350", userId: 2),
                new Blog(id: 5, title: "Blog 5", content: "Blog 5 Description",summary:"summary", smallImageUrl: "https://via.placeholder.com/150", largeImageUrl: "https://via.placeholder.com/350", userId: 3),
                new Blog(id: 6, title: "Blog 6", content: "Blog 6 Description",summary:"summary", smallImageUrl: "https://via.placeholder.com/150", largeImageUrl: "https://via.placeholder.com/350", userId: 3),
                new Blog(id: 7, title: "Blog 7", content: "Blog 7 Description",summary:"summary", smallImageUrl: "https://via.placeholder.com/150", largeImageUrl: "https://via.placeholder.com/350", userId: 4),
                new Blog(id: 8, title: "Blog 8", content: "Blog 8 Description",summary:"summary", smallImageUrl: "https://via.placeholder.com/150", largeImageUrl: "https://via.placeholder.com/350", userId: 4),
                new Blog(id: 9, title: "Blog 9", content: "Blog 9 Description",summary:"summary", smallImageUrl: "https://via.placeholder.com/150", largeImageUrl: "https://via.placeholder.com/350", userId: 5),
                new Blog(id: 10, title: "Blog 10", content: "Blog 10 Description",summary:"summary", smallImageUrl: "https://via.placeholder.com/150", largeImageUrl: "https://via.placeholder.com/350", userId: 5)

            });
    }
}
