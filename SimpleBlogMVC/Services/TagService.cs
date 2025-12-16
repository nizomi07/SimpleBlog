using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleBlogMVC.Data;
using SimpleBlogMVC.Models;
using SimpleBlogMVC.Models.Entities;

namespace SimpleBlogMVC.Services;

public class TagService(DataContext context, IMapper mapper) : ITagService
{
    public async Task<List<Tag>> GetAllTagsAsync()
    {
        var query = context.Tags.AsQueryable();

        return await query.ToListAsync();
    }

    public async Task<Tag> AddTagAsync(TagAddViewModel model)
    {
        var tag = mapper.Map<Tag>(model);
        context.Tags.Add(tag);
        await context.SaveChangesAsync();
        
        return tag;
    }
}