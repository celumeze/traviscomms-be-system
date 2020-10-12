using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TravisComms.CsvProcessing.Mapper;
using TravisComms.Data.Entities.Models;

namespace TravisComms.CsvProcessing.Helper
{
    public class CustomAttributesParserHelper
    {
        public static CustomAttributeIndex ParseCustomAttributes(StreamReader streamReaderFromFile, string separator, 
                                                                ContactHeader contactHeader)
        {

            CustomAttributeIndex caIndex = new CustomAttributeIndex();
            PropertyInfo[] caIndexProps = caIndex.GetType().GetProperties();
            var headerRowText = streamReaderFromFile.ReadLine();
            if (!string.IsNullOrWhiteSpace(headerRowText))
            {
                string[] headers = headerRowText.Split(separator);
                for (int i = 0; i < headers.Length; i++)
                {
                    if (headers[i] != contactHeader.contactNumberHeader && headers[i] != contactHeader.firstNameHeader && headers[i] != contactHeader.lastNameHeader)
                    {
                        caIndexProps[i].SetValue(caIndex, i);
                    }
                }
                //ContactsCsvParserHelper.GetContactRow(streamReaderFromFile, contactHeader, caIndex, accountHolderId, true);
                return caIndex;
            }
            throw new NullReferenceException();
        }
    }
}
