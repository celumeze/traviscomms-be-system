using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravisComms.CsvProcessing.Mapper;

namespace TravisComms.CsvProcessing.Interfaces
{
    public interface IContactsResultProcessor
    {
        Task ProcessAsync(FileStream fileStream, ContactHeader contactHeader, 
                          string separator, Guid accountHolderId, 
                          string filePath, CancellationToken cancellationToken = default);
        Task<dynamic> UploadAsync(FileStream fileStream, ContactHeader contactHeader,
                          string separator, Guid accountHolderId,
                          string filePath, CancellationToken cancellationToken = default);
    }
}
