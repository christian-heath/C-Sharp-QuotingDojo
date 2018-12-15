using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using quotingdojo.Models;

namespace quotingdojo.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("quotes")]
        public IActionResult quotes()
        {
            List<Dictionary<string, object>> AllPosts = DbConnector.Query("SELECT * FROM post");
            ViewBag.Posts = AllPosts;
            return View();
        }

        [HttpPost("quotes")]
        public IActionResult add(Post post)
        {
            if(ModelState.IsValid)
            {
                string query = $"INSERT INTO post (Name, Quote) VALUES ('{post.Name}', '{post.Quote}')";
                DbConnector.Execute(query);
                return RedirectToAction("quotes");
            }
            else{
                return View("index");
            }
        }
    }
}