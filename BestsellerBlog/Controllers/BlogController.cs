using BestsellerBlog.DAL;
using BestsellerBlog.Models;
using Microsoft.AspNetCore.Mvc;


namespace BestsellerBlog.Controllers
{

    public class BlogController : Controller
    {
        private BlogService blogService = new BlogService();

        //Get: Posts
        public IActionResult Index()
        {
            var posts = blogService.PostRepository.GetAllPosts().OrderByDescending(x=>x.Id).ToList();
            return View(posts);
        }

        // GET: Blog/Details/5
        public IActionResult DetailsPost(int id)
        {
            var post = blogService.PostRepository.GetPostById(id);
            if (post != null)
            {
                return View(post);
            }
            return RedirectToAction("Index");
        }
        // GET: Blog/CreatePost
        public IActionResult CreatePost()
        {
            return View();
        }

        // POST: Blog/CreatePost
        [HttpPost]
        public ActionResult CreatePost([Bind(include: "Title,Description")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.CreatedDate = DateTime.Now;
                blogService.PostRepository.InsertPost(post);
                blogService.Save();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Blog/EditPost/5
        public IActionResult EditPost(int id)
        {
            if (id == 0)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }

            Post post = blogService.PostRepository.GetPostById(id);

            if (post == null)
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }
            return View(post);
        }

        // POST: Blog/EditPost/5
        [HttpPost]
        public IActionResult EditPost([Bind(include: "Id,Title,Description")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.CreatedDate = DateTime.Now;
                blogService.PostRepository.UpdatePost(post);
                blogService.Save();
                return RedirectToAction("Index");
            }
            return View(post);
        }


        // Post: Blog/Delete/5
        [HttpPost]
        public ActionResult DeletePost(int id)
        {
            if(id == 0)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }

            Post post = blogService.PostRepository.GetPostById(id);

            if(post == null)
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }
            else
            {
                blogService.PostRepository.DeletePostById(id);
                blogService.Save();
            }
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                blogService.Dispose();
            }
            base.Dispose(disposing);
        }




    }
}
