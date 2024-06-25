using RevenueRecognitionSystem.Domain.Models.SoftwareLicense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.Interfaces.Repositories
{
    public interface ISubscriptionRepository
    {
        Subscription GetSubscriptionById(Guid id);
        void Add(Subscription subscription);
    }
}
