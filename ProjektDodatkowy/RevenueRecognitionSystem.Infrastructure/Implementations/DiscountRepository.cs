using RevenueRecognitionSystem.Domain.Interfaces.Repositories;
using RevenueRecognitionSystem.Domain.Models.SoftwareLicense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Infrastructure.Implementations
{
    public class DiscountRepository : IDiscountRepository
    {
        ReveuneDbContext _dbContext;
        public DiscountRepository(ReveuneDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Discount> GetCurrentAvaliableDiscounts()
        {
            
          return _dbContext.Discounts.Where(x => x.DateFrom <= DateTime.UtcNow && x.DateTo > DateTime.UtcNow).ToList();
        }
    }
}
