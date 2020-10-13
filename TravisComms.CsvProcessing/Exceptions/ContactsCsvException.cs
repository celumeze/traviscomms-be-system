using System;
using System.Collections.Generic;
using System.Text;

namespace TravisComms.CsvProcessing.Exceptions
{
    public class ContactsCsvException : Exception
    {
        public ContactsCsvException(string message):base(message)
        {

        }
    }
}
