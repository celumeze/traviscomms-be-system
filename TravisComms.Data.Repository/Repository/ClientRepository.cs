using TravisComms.Data.Entities.Models;
using TravisComms.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravisComms.Data.Repository.Repository
{
    public class ClientRepository : RepositoryBase, IClientRepository
    {
        private readonly TravisCommsSqlDbContext _TravisCommsSqlDbContext;
        public ClientRepository(TravisCommsSqlDbContext TravisCommsSqlDbContext) : base(TravisCommsSqlDbContext)
        {
            _TravisCommsSqlDbContext = TravisCommsSqlDbContext;
        }

        public Client AddClient(Client client)
        {
            client.ClientId = Guid.NewGuid();
            _TravisCommsSqlDbContext.Entry(client).State = EntityState.Added;
            return client;
        }

        public async Task<Client> GetClientByIdAsync(Guid clientId)
        {
            return await _TravisCommsSqlDbContext.Clients?.FirstOrDefaultAsync(c => c.ClientId == clientId);
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _TravisCommsSqlDbContext.Clients?.ToListAsync();
        }

        public async Task<IEnumerable<Client>> GetClientsBySubscriptionTypeAsync(Guid subscriptionTypeId)
        {
            return await _TravisCommsSqlDbContext.Clients?.Where(c => c.SubscriptionTypeId == subscriptionTypeId).ToListAsync();
        }

        public Client RemoveClient(Client client)
        {
            _TravisCommsSqlDbContext.Entry(client).State = EntityState.Deleted;
            return client;
        }

        public Client UpdateClient(Client client)
        {
            _TravisCommsSqlDbContext.Entry(client).State = EntityState.Modified;
            return client;
        }
    }
}
