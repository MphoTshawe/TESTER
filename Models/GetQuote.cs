using System.ComponentModel.DataAnnotations;

namespace TESTER.Models
{
    public class GetQuote
    {
        [Key]
        
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required.")]
        [StringLength(50, ErrorMessage = "Surname cannot exceed 50 characters.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(10, ErrorMessage = "Title cannot exceed 10 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Cell number is required.")]
        [Phone(ErrorMessage = "Invalid cell number.")]
        [StringLength(20, ErrorMessage = "Cell number cannot exceed 20 characters.")]
        public string CellNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Plan is required.")]
        [StringLength(20, ErrorMessage = "Plan cannot exceed 20 characters.")]
        public string Plan { get; set; }

        
        [StringLength(500, ErrorMessage = "Message cannot exceed 500 characters.")]
        public string Message { get; set; }

    }
}
  