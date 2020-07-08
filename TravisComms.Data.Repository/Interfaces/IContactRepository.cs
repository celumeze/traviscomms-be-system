using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravisComms.Data.Entities.Models;

namespace TravisComms.Data.Repository.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContactDetailsAsync();
        Task<Contact> AddContactDetails(Contact contactDetails);

    }
}
