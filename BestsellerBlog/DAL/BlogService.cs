using BestsellerBlog.Data;
using BestsellerBlog.Repository;

namespace BestsellerBlog.DAL
{
    public class BlogService: IDisposable
    {
        private BlogDbContext _context = new BlogDbContext();
        private readonly PostRepository? _postRepository;

        public PostRepository PostRepository
        {
            get
            {
                return (_postRepository ?? new PostRepository(_context));
            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
