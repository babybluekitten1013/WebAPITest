using System.ComponentModel.DataAnnotations;

namespace WebAPITest.Models
{
    public class FeedbackData
    {
        [Required, Key]
        public int FeedbackId { get; set; }

        [Required]
        public int FeedbackAuthorId { get; set; }

        [Required]
        public string FeedbackBody { get; set; }

    }
}
