using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace TESTER.Models
{
    public class Beneficiaries
    {
        
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "First names are required.")]
        [Display(Name = "First Names")]
        [StringLength(100, ErrorMessage = "First names cannot exceed 100 characters.")]
        public string FullName { get; set; }

       


        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Date of birth is required.")]
        public DateTime? DateOfBirth { get; set; }


        [Required(ErrorMessage = "ID Number is required.")]
        [Display(Name = "ID Number")]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "ID Number must be exactly 13 digits.")]
        public string IDNumber { get; set; }

        
        [Required(ErrorMessage = "Cell No. is required.")]
        [Display(Name = "Cell No.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
         public string CellNo { get; set; }


        [Display(Name = "Commencement Date")]
        [DataType(DataType.Date)]
        public DateTime? CommencementDate { get; set; }

        
    }

    



}

