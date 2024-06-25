using RevenueRecognitionSystem.Domain.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.Interfaces.Repositories
{
    public interface ICompanyClientRepository
    {
        CompanyClient? GetById(Guid Id);
        List<CompanyClient> GetAll();

        void Add(CompanyClient client);
    }
}
