﻿using CsvHelper;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using TravisComms.CsvProcessing.Helper;
using TravisComms.CsvProcessing.Interfaces;
using TravisComms.CsvProcessing.Mapper;
using TravisComms.Data.Entities.Models;

namespace TravisComms.CsvProcessing.Processors
{
    public class ContactsCsvParser : IContactsCsvParser
    {
        public IEnumerable<dynamic> ParseContactsCsv(FileStream fileStream, string separator, ContactHeader contactHeader, Guid accountHolderId)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(contactHeader?.contactNumberHeader))
                {
                    using (var reader = new StreamReader(fileStream))
                    using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csvReader.Configuration.TrimOptions = CsvHelper.Configuration.TrimOptions.Trim;
                        csvReader.Configuration.Delimiter = separator;
                        csvReader.Configuration.HasHeaderRecord = true;
                       
                        var records =  csvReader.GetRecords<dynamic>()?.ToList();
                        if(records != null)
                        {                          
                            //update non header records
                            foreach (var record in records)
                            {
                                record.isHeader = false.ToString().ToLower();
                                record.id = Guid.NewGuid().ToString();
                                record.accountHolderId = accountHolderId.ToString();
                            }
                        }                      
                        return records;                       
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            throw new NullReferenceException();
        }
    }
}
