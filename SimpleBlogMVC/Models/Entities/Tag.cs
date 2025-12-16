namespace SimpleBlogMVC.Models.Entities;

public class Tag : BaseEntity
{
    public string Name { get; set; }

    public ICollection<Post> Posts { get; set; }
}