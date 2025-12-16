using Microsoft.AspNetCore.Mvc;
using SimpleBlogMVC.Models;
using SimpleBlogMVC.Services;

namespace SimpleBlogMVC.Controllers;

public class PostController(IPostService service) : Controller
{
    public async Task<IActionResult> Index()
    {
        ViewBag.Posts = await service.GetAllPostsAsync();
        
        return View();
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] PostAddViewModel model)
    {
        await service.AddPostAsync(model);
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await service.DeletePostAsync(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(PostUpdateViewModel model)
    {
        ViewBag.UpdatePost = model;
        
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromForm] PostUpdateViewModel model)
    {
        await service.UpdatePostAsync(model);
        return RedirectToAction("Index");
    }
    
    
}