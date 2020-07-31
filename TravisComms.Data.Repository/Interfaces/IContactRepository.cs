using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravisComms.Data.Entities.Models;

namespace TravisComms.Data.Repository.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<dynamic>> GetContactDetailsAsync(string accountHolderId);
        Task<Contact> AddContactDetails(Contact contactDetails);

    }
}
