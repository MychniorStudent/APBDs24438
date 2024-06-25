using RevenueRecognitionSystem.Domain.Interfaces.Repositories;
using RevenueRecognitionSystem.Domain.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Infrastructure.Implementations
{
    public class IndividualClientRepository : IIndividualClientRepository
    {
        private readonly ReveuneDbContext _dbContext;
        public IndividualClientRepository(ReveuneDbContext dbContext)
        {

            _dbContext = dbContext;

        }

        public void Add(IndividualClient client)
        {
            _dbContext.IndividualClients.Add(client);
        }

        public IEnumerable<IndividualClient> GetAll()
        {
           return _dbContext.IndividualClients.ToList();
        }
        public IndividualClient? GetById(Guid id) 
        {
            return _dbContext.IndividualClients.FirstOrDefault(x => x.Id == id);
        }
    }
}
