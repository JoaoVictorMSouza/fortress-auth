using Microsoft.AspNetCore.Authorization;

namespace FortressAuth.Filters.Attributes
{
    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        public AuthorizeUserAttribute() : base(policy: "USER")
        {
            
        }
    }
}
