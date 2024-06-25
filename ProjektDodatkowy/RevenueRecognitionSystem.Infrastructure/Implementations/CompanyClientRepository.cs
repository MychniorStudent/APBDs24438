using RevenueRecognitionSystem.Domain.Interfaces.Repositories;
using RevenueRecognitionSystem.Domain.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Infrastructure.Implementations
{
    public class CompanyClientRepository : ICompanyClientRepository
    {
        private readonly ReveuneDbContext _dbContext;
        public CompanyClientRepository(ReveuneDbContext dbContext)
        {

            _dbContext = dbContext;

        }

        public void Add(CompanyClient client)
        {
            _dbContext.Add(client);
        }

        public List<CompanyClient> GetAll()
        {
            return _dbContext.CompanyClients.ToList();
        }

        public CompanyClient? GetById(Guid Id)
        {
            return _dbContext.CompanyClients.FirstOrDefault(c => c.Id == Id);
        }
    }
}
