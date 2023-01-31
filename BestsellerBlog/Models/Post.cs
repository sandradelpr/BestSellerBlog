using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BestsellerBlog.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter title")]
        [DisplayName("Title")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Please enter description")]
        [DisplayName("Description")]
        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
