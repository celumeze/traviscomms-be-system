using System;
using System.Collections.Generic;
using System.Text;

namespace TravisComms.Processor.Tests.ExtTestData
{
    public class ContactsCsvTestData
    {
        public static IEnumerable<object[]> ContactsTestCsv
        {
            get
            {
                yield return new object[] { @"ExtTestData\Contacts1.csv", 8, "," };
                yield return new object[] { @"ExtTestData\Contacts2.csv", 400, "," };
                yield return new object[] { @"ExtTestData\Contacts3.csv", 10375, "|" };
            }
        }

        public static IEnumerable<object[]> ContactsTestWithoutNumberOfRows
        {
            get
            {
                yield return new object[] { @"ExtTestData\Contacts1.csv", "," };
                yield return new object[] { @"ExtTestData\Contacts2.csv", "," };
                yield return new object[] { @"ExtTestData\Contacts3.csv", "|" };
            }
        }
    }
}
