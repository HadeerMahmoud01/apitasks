using Microsoft.AspNetCore.Identity;

namespace apilab3.Data
{
    public class Lawyer:IdentityUser
    {
        public string? specialization { get; set; }
    }
}
