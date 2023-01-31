using BestsellerBlog.Models;

namespace BestsellerBlog.Repository
{
    public interface IPostRepository
    {
        void InsertPost(Post post);
        IList<Post> GetAllPosts();
        Post GetPostById(int id);
        void UpdatePost(Post post);
        void DeletePostById(int id);
    }
}
