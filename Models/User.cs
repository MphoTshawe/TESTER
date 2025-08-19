using Microsoft.AspNetCore.Identity;

namespace TESTER.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }



    }
}
