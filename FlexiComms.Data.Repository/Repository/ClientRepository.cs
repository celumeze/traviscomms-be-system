using FlexiComms.Data.Entities.Models;
using FlexiComms.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiComms.Data.Repository.Repository
{
    public class ClientRepository : RepositoryBase, IClientRepository
    {
        private readonly FlexiCommsSqlDbContext _flexiCommsSqlDbContext;
        public ClientRepository(FlexiCommsSqlDbContext flexiCommsSqlDbContext) : base(flexiCommsSqlDbContext)
        {
            _flexiCommsSqlDbContext = flexiCommsSqlDbContext;
        }

        public Client AddClient(Client client)
        {
            _flexiCommsSqlDbContext.Entry(client).State = EntityState.Added;
            return client;
        }

        public async Task<Client> GetClientByIdAsync(Guid clientId)
        {
            return await _flexiCommsSqlDbContext.Clients?.FirstOrDefaultAsync(c => c.ClientId == clientId);
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _flexiCommsSqlDbContext.Clients?.ToListAsync();
        }

        public async Task<IEnumerable<Client>> GetClientsBySubscriptionTypeAsync(Guid subscriptionTypeId)
        {
            return await _flexiCommsSqlDbContext.Clients?.Where(c => c.SubscriptionTypeId == subscriptionTypeId).ToListAsync();
        }

        public Client RemoveClient(Client client)
        {
            _flexiCommsSqlDbContext.Entry(client).State = EntityState.Deleted;
            return client;
        }

        public Client UpdateClient(Client client)
        {
            _flexiCommsSqlDbContext.Entry(client).State = EntityState.Modified;
            return client;
        }
    }
}
