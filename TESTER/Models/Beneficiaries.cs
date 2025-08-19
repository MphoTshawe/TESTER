using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace TESTER.Models
{
    public class Beneficiaries
    {
        
        public Beneficiaries()
        {
            RelatedPersons = new List<RelatedPersonViewModel>();
        }
        public List<RelatedPersonViewModel> RelatedPersons { get; set; } = new();
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "First names are required.")]
        [Display(Name = "First Names")]
        [StringLength(100, ErrorMessage = "First names cannot exceed 100 characters.")]
        public string FirstNames { get; set; }

        [Required(ErrorMessage = "Surname is required.")]
        [StringLength(50, ErrorMessage = "Surname cannot exceed 50 characters.")]
        public string Surname { get; set; }

        [Display(Name = "Marital Status")]
        public bool IsMarried { get; set; }
        public bool IsSingle { get; set; }
        public bool IsWidow { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Date of birth is required.")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "ID Number is required.")]
        [Display(Name = "ID Number")]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "ID Number must be exactly 13 digits.")]
        public string IDNumber { get; set; }

        [StringLength(200, ErrorMessage = "Postal address cannot exceed 200 characters.")]
        [Display(Name = "Postal Address")]
        public string PostalAddress { get; set; }

        [Required(ErrorMessage = "Cell No. is required.")]
        [Display(Name = "Cell No.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
         public string CellNo { get; set; }

        [Required(ErrorMessage = "Place is required.")]
        public string Place { get; set; }

        [Display(Name = "Commencement Date")]
        [DataType(DataType.Date)]
        public DateTime? CommencementDate { get; set; }

        [Range(0, 16, ErrorMessage = "Family cover must be between 0 and 1,000,000.")]
        [Display(Name = "Family Cover")]
        public int? FamilyCover { get; set; }

        
      

        
    }

    public class RelatedPersonViewModel
    {
        [StringLength(50, ErrorMessage = "Relationship cannot exceed 50 characters.")]
        public string Relationship { get; set; }


        [StringLength(100, ErrorMessage = "First names cannot exceed 100 characters.")]
        [Display(Name = "First Names")]
        public string FirstNames { get; set; }

        [StringLength(50, ErrorMessage = "Surname cannot exceed 50 characters.")]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }
        [Key]
        [Display(Name = "ID Number")]
        public string IDNumber { get; set; }
    }



}

