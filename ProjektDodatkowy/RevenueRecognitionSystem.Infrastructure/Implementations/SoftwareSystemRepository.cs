using Microsoft.EntityFrameworkCore;
using RevenueRecognitionSystem.Domain.Interfaces.Repositories;
using RevenueRecognitionSystem.Domain.Models.SoftwareLicense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Infrastructure.Implementations
{
    public class SoftwareSystemRepository : ISoftwareSystemRepository
    {
        private readonly ReveuneDbContext _dbContext;
        public SoftwareSystemRepository(ReveuneDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<SoftwareSystem> GetAll()
        {
            return _dbContext.SoftwareSystems.Include(x=>x.Contracts).Include(b=>b.Subscriptions).ToList();
        }

        public SoftwareSystem? GetSoftwareSystemById(Guid id)
        {
            return _dbContext.SoftwareSystems.Include(x=>x.Contracts).Include(a=>a.Subscriptions)
                .FirstOrDefault(s => s.Id == id);
        }
    }
}
