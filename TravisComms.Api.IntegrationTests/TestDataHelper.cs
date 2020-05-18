using System;
using System.Collections.Generic;
using System.Text;
using TravisComms.Api.Dto;

namespace TravisComms.Api.IntegrationTests
{
    public static class TestDataHelper
    {
        public static AddAccountHolderDto CreateNewAccountHolder()
        {
            return new AddAccountHolderDto();
        }
    }
}
