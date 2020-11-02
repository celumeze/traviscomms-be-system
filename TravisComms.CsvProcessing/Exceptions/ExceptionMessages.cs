using System;
using System.Collections.Generic;
using System.Text;

namespace TravisComms.CsvProcessing.Exceptions
{
    public class ExceptionMessages
    {
        public const string InvalidContactNumberHeaderOrSeparator = "Specified contact number header or separator not found";
        public const string MissingContactNumber = "Contact number is required";
        public const string ContactNumberExceededLength = "Contact number cannot be more than 20 characters";
    }
}
