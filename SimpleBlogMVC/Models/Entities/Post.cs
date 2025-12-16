namespace SimpleBlogMVC.Models.Entities;

public class Post : BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PublicationDate { get; set; } = DateTime.Now;

    public ICollection<Tag> Tags { get; set; }
}