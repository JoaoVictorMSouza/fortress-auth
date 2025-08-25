using Microsoft.AspNetCore.Authorization;

namespace FortressAuth.Filters.Attributes
{
    public class AuthorizeAdminAttribute : AuthorizeAttribute
    {
        public AuthorizeAdminAttribute() : base(policy: "ADMIN")
        {
            
        }
    }
}
