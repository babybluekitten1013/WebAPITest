using System.ComponentModel.DataAnnotations;

namespace WebAPITest.Models
{
    public class BusinessContactDetails
    {
        [Required, Key]
        public int BusinessId { get; set; }

        [Required]
        public string BusinessContactFirstName { get; set; }
        public string? BusinessContactLastName { get; set; }

        [Required]
        public string BusinessName { get; set; }

        [Required]
        public string BusinessAddress { get; set; }
        public string? BusinessCity { get; set; }
        public string? BusinessState { get; set; }
        public string? BusinessZip { get; set; }

        [Required]
        public string BusinessPhone { get; set; }
        public string? BusinessFax { get; set; }
        public string? BusinessEmail { get; set; }
    }
}
