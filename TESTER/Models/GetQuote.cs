using System.ComponentModel.DataAnnotations;

namespace TESTER.Models
{
    public class GetQuote
    {
        [Key]
        [Required]
        public string ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
       
        public string Title { get; set; }
        [Required]
        
        public string CellNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]

        public string Plan { get; set; }
        [Required]

        public string Message { get; set; }


    }
}
  