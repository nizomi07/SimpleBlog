using SimpleBlogMVC.Models;
using SimpleBlogMVC.Models.Entities;

namespace SimpleBlogMVC.Services;

public interface ITagService
{
    Task<List<Tag>> GetAllTagsAsync();
    Task<Tag> AddTagAsync(TagAddViewModel model);
}