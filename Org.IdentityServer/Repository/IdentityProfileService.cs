using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Org.IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Org.IdentityServer.Repository
{
    public class IdentityProfileService : IProfileService
    {
        private readonly IUserClaimsPrincipalFactory<MainUser> _claimsFactory;
        private readonly UserManager<MainUser> _userManager;

        public IdentityProfileService(IUserClaimsPrincipalFactory<MainUser> claimsFactory, UserManager<MainUser> userManager)
        {
            _claimsFactory = claimsFactory;
            _userManager = userManager;
        }


        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);
            if(user == null)
            {
                throw new Exception();
            }

            var principal = await _claimsFactory.CreateAsync(user);
            var claims = principal.Claims.ToList();
            context.IssuedClaims = new List<System.Security.Claims.Claim>
            {
               new System.Security.Claims.Claim("AccountHolderId", user.AccountHolderId.ToString())             
            };
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);
            context.IsActive = user != null;
        }
    }
}
