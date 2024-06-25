using RevenueRecognitionSystem.Domain.DTOs.ClientDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.Interfaces.Services
{
    public interface IClientService
    {
        bool AddIndividualClient(AddIndividualClientDTO dto);
        bool AddCompanyClient(AddCompanyClientDTO dto);
        bool EditIndividualClient(EditIndividualClientDTO dto);
        bool EditCompanyClient(EditCompanyClientDTO dto);
        bool DeleteIndividualClient(Guid id);
    }
}
