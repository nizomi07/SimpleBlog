using SimpleBlogMVC.Models;
using SimpleBlogMVC.Models.Entities;

namespace SimpleBlogMVC.Services;

public interface IPostService
{
    Task<Post> AddPostAsync(PostAddViewModel model);
    Task<Post> UpdatePostAsync(PostUpdateViewModel model);
    Task<List<Post>> GetAllPostsAsync();
    Task<Post> Details(int postId);
    Task<Post> DeletePostAsync(int postId);
}