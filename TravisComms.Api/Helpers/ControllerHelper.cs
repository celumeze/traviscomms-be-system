using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace TravisComms.Api.Helpers
{
    public static class ControllerHelper
    {
        public static string GenerateVerifyEmailLink(IUrlHelper urlHelper, ControllerContext controllerContext, string userId, string verificationCode)
        {
            var callbackUrl = urlHelper.Page("/verifyEmail",
                                             pageHandler:null,
                                             values: new { userId = userId, code = verificationCode },
                                             protocol: controllerContext.HttpContext.Request.Scheme);
           return HtmlEncoder.Default.Encode(callbackUrl);
        }
    }
}
