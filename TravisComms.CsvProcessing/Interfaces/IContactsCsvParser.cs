using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TravisComms.CsvProcessing.Mapper;
using TravisComms.Data.Entities.Models;

namespace TravisComms.CsvProcessing.Interfaces
{
    public interface IContactsCsvParser
    {
        IEnumerable<dynamic> ParseContactsCsv(FileStream stream, string separator, ContactHeader contactHeader, Guid accountHolderId);
    }
}
