using TESTER.Models;
namespace TESTER.ViewModels

{
    public class InsuredFormViewModel
    {
        public string MainMemberId { get; set; }
        public List<InsuredPerson> InsuredPersons { get; set; } = new List<InsuredPerson>();


    }
}
