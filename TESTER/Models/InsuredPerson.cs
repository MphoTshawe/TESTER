using System.ComponentModel.DataAnnotations;

namespace TESTER.Models
{
    public class InsuredPerson
    {
        [Key]
        public int Id { get; set; }
        public string RelationshipToPrincipalMember { get; set; }
        public string FirstNames { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdNumber { get; set; }
        public string MainMemberId { get; set; } // <-- Add this property
    }
}
