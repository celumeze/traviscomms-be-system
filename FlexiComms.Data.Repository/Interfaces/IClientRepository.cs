using FlexiComms.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlexiComms.Data.Repository.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client> GetClientByIdAsync(Guid clientId);
        Task<IEnumerable<Client>> GetClientsBySubscriptionTypeAsync(Guid subscriptionTypeId);
        Client AddClient(Client client);
        Client UpdateClient(Client client);
        Client RemoveClient(Client client);
    }
}
