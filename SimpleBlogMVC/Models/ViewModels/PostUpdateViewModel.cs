namespace SimpleBlogMVC.Models;

public class PostUpdateViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PublicationDate { get; set; }
}