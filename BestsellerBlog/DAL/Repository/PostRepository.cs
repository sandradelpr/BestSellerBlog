using BestsellerBlog.Data;
using BestsellerBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace BestsellerBlog.Repository
{
    public class PostRepository : IPostRepository
    {
        private BlogDbContext _context;

        public PostRepository(BlogDbContext context)
        {
            _context = context;
        }

        public void DeletePostById(int id)
        {
            var post = GetPostById(id);

            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }
                
        }

        public IList<Post> GetAllPosts()
        {
            return _context.Posts.ToList();
        }

        public Post GetPostById(int id)
        {
            return _context.Posts.Find(id);
        }

        public void InsertPost(Post post)
        {
            _context.Posts.Add(post);
        }

        public void UpdatePost(Post post)
        {
            _context.Attach(post);
            _context.Entry(post).State = EntityState.Modified;
        }
    }
}
