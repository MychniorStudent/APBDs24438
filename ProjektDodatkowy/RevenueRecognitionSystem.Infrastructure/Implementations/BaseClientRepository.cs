using Microsoft.EntityFrameworkCore;
using RevenueRecognitionSystem.Domain.Interfaces.Repositories;
using RevenueRecognitionSystem.Domain.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Infrastructure.Implementations
{
    public class BaseClientRepository : IBaseClientRepository
    {
        ReveuneDbContext _dbContext;
        public BaseClientRepository(ReveuneDbContext dbContext)
        {
            _dbContext= dbContext;
        }
        public BaseClient? GetClientById(Guid id)
        {
            return _dbContext.Clients.Include(x=>x.Contracts)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
