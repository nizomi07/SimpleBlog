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
        // ViewBag.UpdatePost = model;
        //
        // return View(model);
        
        
        var post = await service.Details(model.Id);

        if (post == null)
            return NotFound();

        var myModel = new PostUpdateViewModel
        {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content
        };
        
        ViewBag.UpdatePost = myModel;

        return View(myModel);
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromForm] PostUpdateViewModel model)
    {
        Console.WriteLine(model.Id);
        await service.UpdatePostAsync(model);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int id)
    {
        var postDetails = await service.Details(id);
        
        ViewBag.PostDetails = postDetails;
        
        return View(postDetails);
    }
}