using BestsellerBlog.Models;
using Microsoft.AspNetCore.Mvc;

namespace BestsellerBlog.Controllers
{
    public class BlogController : Controller
    {
        private static List<Post> _blogList = new List<Post>();

        public IActionResult Index()
        {
           
            return View(_blogList);
        }

        public IActionResult EditPost(int id)
        {
            var post = _blogList.SingleOrDefault(x => x.Id == id);
            return View(post);
        }

        [HttpPost]
        public IActionResult EditPost(Post post)
        {
            var edit = _blogList.SingleOrDefault(x => x.Id == post.Id);
            if(edit != null)
            {
                edit.Title = post.Title;
                edit.Content = post.Content;
                edit.CreatedDate = DateTime.Now;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var post = _blogList.SingleOrDefault(x => x.Id == id);
            if(post != null)
                _blogList.Remove(post);

            return RedirectToAction("Index");
        }

        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(string title, string content)
        {
            _blogList.Add(new Post { Id = _blogList.Count()+1, Title = title, Content = content, CreatedDate = DateTime.Now });
            return RedirectToAction("Index");
        }



    }
}
