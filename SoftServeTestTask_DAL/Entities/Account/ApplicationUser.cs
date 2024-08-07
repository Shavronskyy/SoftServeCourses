using Microsoft.AspNetCore.Identity;


namespace SoftServeTestTask_DAL.Entities.Account
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
