using WebAPITest.Areas.Identity.Data;

namespace WebAPITest.Models
{
    public class Content
    {
        public int ContentId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string AuthorID { get; set; }
        public VisibilityStatus Visibility { get; set; }
        public int CategoryId { get; set; } 

        public virtual Category? Category {  get; set; }

        public virtual ContentUser Author { get; set; }
    }
}
