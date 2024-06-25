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
    public class SubscriptionRepository : ISubscriptionRepository
    {
        ReveuneDbContext _dbContext;
        public SubscriptionRepository(ReveuneDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Subscription subscription)
        {
            _dbContext.Subscriptions.Add(subscription);
        }

        public Subscription GetSubscriptionById(Guid id)
        {
            return _dbContext.Subscriptions.Include(x=>x.SubPayments)
                .FirstOrDefault(s => s.Id == id);
        }
    }
}
