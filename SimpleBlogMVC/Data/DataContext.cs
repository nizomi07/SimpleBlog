using Microsoft.EntityFrameworkCore;
using SimpleBlogMVC.Models.Entities;

namespace SimpleBlogMVC.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Tag> Tags { get; set; }
}