using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleBlogMVC.Data;
using SimpleBlogMVC.Models;
using SimpleBlogMVC.Models.Entities;

namespace SimpleBlogMVC.Services;

public class PostService(DataContext context, IMapper mapper) : IPostService
{
    public async Task<Post> AddPostAsync(PostAddViewModel model)
    {
        var post = mapper.Map<Post>(model);
        post.PublicationDate = DateTime.UtcNow;
        context.Posts.Add(post);
        await context.SaveChangesAsync();
        
        return post;
    }

    public async Task<Post> UpdatePostAsync(PostUpdateViewModel model)
    {
        var post = mapper.Map<Post>(model);
        context.Posts.Update(post);
        await context.SaveChangesAsync();
        
        return post;
    }

    public async Task<List<Post>> GetAllPostsAsync()
    {
        var query = context.Posts.AsQueryable();

        return await query.ToListAsync();
    }

    public Task<Post> Details(int postId)
    {
        var query = context.Posts.AsQueryable();
        
        return query.FirstAsync(p => p.Id == postId);
    }

    public async Task<Post> DeletePostAsync(int postId)
    {
        var post = await context.Posts.FindAsync(postId);
        context.Posts.Remove(post!);
        await context.SaveChangesAsync();
        
        return post!;
    }
}