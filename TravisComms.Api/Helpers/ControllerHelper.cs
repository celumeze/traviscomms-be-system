using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using TravisComms.Api.Dto;
using TravisComms.CsvProcessing.Mapper;

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

        public static ContactsCsvDto CreateContactsCsvInfo(IFormFile file, NameValueCollection nameValueCollection)
        {
            return new ContactsCsvDto
            {
                separatorText = nameValueCollection.Get(nameof(ContactsCsvDto.separatorText)),
                ContactHeader = new ContactHeader
                {
                    firstNameHeader = nameValueCollection.Get(nameof(ContactHeader.firstNameHeader)),
                    lastNameHeader = nameValueCollection.Get(nameof(ContactHeader.lastNameHeader)),
                    contactNumberHeader = nameValueCollection.Get(nameof(ContactHeader.contactNumberHeader)),
                },
                file = file
            };
        }
    }
}
