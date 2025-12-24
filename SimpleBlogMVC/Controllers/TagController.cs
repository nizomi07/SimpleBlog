using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleBlogMVC.Models;
using SimpleBlogMVC.Services;

namespace SimpleBlogMVC.Controllers;

public class TagController(ITagService service) : Controller
{
    [Authorize]
    public async Task<IActionResult> Index()
    {
        ViewBag.Tags = await service.GetAllTagsAsync();
        
        return View();
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] TagAddViewModel model)
    {
        await service.AddTagAsync(model);
        
        return RedirectToAction("Index");
    }
}