using CsvHelper;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TravisComms.CsvProcessing.Mapper;
using TravisComms.Data.Entities.Models;

namespace TravisComms.CsvProcessing.Helper
{
    public static class ContactsCsvParserHelper
    {
        public static Contact GetContactRow(CsvReader csvReader, ContactHeader contactHeader, CustomAttributeIndex caIndex, Guid accountHolderId, bool isHeaderRow = false)
        {
           
            var record = new Contact
            {
                FirstName = csvReader.GetField<string>(contactHeader.firstNameHeader),
                LastName = csvReader.GetField<string>(contactHeader.lastNameHeader),
                ContactNumber = csvReader.GetField<string>(contactHeader.contactNumberHeader),
                CustomAttribute1 = caIndex.CustomAttribute1Index != null ? csvReader.GetField(caIndex.CustomAttribute1Index.Value) : null,
                CustomAttribute2 = caIndex.CustomAttribute2Index != null ? csvReader.GetField(caIndex.CustomAttribute2Index.Value) : null,
                CustomAttribute3 = caIndex.CustomAttribute3Index != null ? csvReader.GetField(caIndex.CustomAttribute3Index.Value) : null,
                CustomAttribute4 = caIndex.CustomAttribute4Index != null ? csvReader.GetField(caIndex.CustomAttribute4Index.Value) : null,
                CustomAttribute5 = caIndex.CustomAttribute5Index != null ? csvReader.GetField(caIndex.CustomAttribute5Index.Value) : null,
                CustomAttribute6 = caIndex.CustomAttribute6Index != null ? csvReader.GetField(caIndex.CustomAttribute6Index.Value) : null,
                CustomAttribute7 = caIndex.CustomAttribute7Index != null ? csvReader.GetField(caIndex.CustomAttribute7Index.Value) : null,
                CustomAttribute8 = caIndex.CustomAttribute8Index != null ? csvReader.GetField(caIndex.CustomAttribute8Index.Value) : null,
                CustomAttribute9 = caIndex.CustomAttribute9Index != null ? csvReader.GetField(caIndex.CustomAttribute9Index.Value) : null,
                CustomAttribute10 = caIndex.CustomAttribute10Index != null ? csvReader.GetField(caIndex.CustomAttribute10Index.Value) : null,
                IsUploadedFromCsv = true,
                IsCsvHeaderRow = isHeaderRow,
                AccountHolderId = accountHolderId
            };
            return record;
        }
    }
}
