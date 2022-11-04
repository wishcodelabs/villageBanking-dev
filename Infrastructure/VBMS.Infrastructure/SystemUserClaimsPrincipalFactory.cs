using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace VBMS.Infrastructure
{
    public class SystemUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, Role>
    {
       public SystemUserClaimsPrincipalFactory(UserManager<User> userManager, RoleManager<Role> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
           
        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {

            var identity = await base.GenerateClaimsAsync(user);            
            identity.AddClaim(new Claim("FullName", user.FirstName + " " + user.LastName));
            identity.AddClaim(new Claim("FirstName", user.FirstName));
            identity.AddClaim(new Claim("LastName", user.LastName));
            identity.AddClaim(new Claim("Guid", user.UserGuid.ToString()));
            identity.AddClaim(new Claim("UserId", user.Id.ToString()));   
            return identity;
        }
    }
}
