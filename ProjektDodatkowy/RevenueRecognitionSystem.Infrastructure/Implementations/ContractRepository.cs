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
    public class ContractRepository : IContractRepository
    {
        ReveuneDbContext _dbContext;
        public ContractRepository(ReveuneDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Contract Add(Contract contract)
        {
            _dbContext.Add(contract);
            return contract;
        }

        public Contract GetContractById(Guid id)
        {
            return _dbContext.Contracts.Include(x=>x.SoftwareSystem).Include(b=>b.Client)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
