using System.ComponentModel.DataAnnotations;

namespace TESTER.Models
{
    public class Claims
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Claim Number")]
        public string ClaimNumber { get; set; }

        [Required]
        [Display(Name = "Main Member")]
        public string MainMember { get; set; }


        [Required]
        [Display(Name = "Main Member ID")]
        public string MainMemberID { get; set; }

        [Required]
        [Display(Name = "Deceased ID")]
        public string DeceasedID { get; set; }

        [Required]
        [Display(Name = "Names of Deceased")]
        public string NameOfDeceased { get; set; }

        [Required]
        [Display(Name = "Date of death ")]
        public DateTime? DateOfDeath { get; set; }

        [Required]
        [Display(Name = "Cause Of Death")]
        public string CauseOfDeath { get; set; }

        [Required]
        [Display(Name = "Claim Date")]
        public DateTime? ClaimDate { get; set; }

    }
}
