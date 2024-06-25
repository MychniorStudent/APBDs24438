using RevenueRecognitionSystem.Domain.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.Interfaces.Repositories
{
    public interface IIndividualClientRepository
    {
        void Add (IndividualClient client);
        IEnumerable<IndividualClient> GetAll ();
        public IndividualClient? GetById(Guid id);
    }
}
