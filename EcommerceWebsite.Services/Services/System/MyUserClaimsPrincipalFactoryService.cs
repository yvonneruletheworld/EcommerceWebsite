using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace ValensBankCore.Services.Services
{
    public class MyUserClaimsPrincipalFactoryService : UserClaimsPrincipalFactory<ApplicationUser>
    {
        private EcomWebDbContext _context;

        public MyUserClaimsPrincipalFactoryService(
        UserManager<ApplicationUser> userManager,
        IOptions<IdentityOptions> optionsAccessor,
        EcomWebDbContext context)
            : base(userManager, optionsAccessor)
        {
            _context = context;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            //get the data from dbcontext
            var client = _context.KhachHangs.Where(x => !x.DaXoa && x.Id == user.Id).FirstOrDefault();

            var identity = await base.GenerateClaimsAsync(user);
            //Get the data from EF core

            if (client != null)
            {
                identity.AddClaim(new Claim("ClientId", client.Id));
            }

            return identity;
        }
    }
}