using RevenueRecognitionSystem.Domain.DTOs.ClientDTOs;
using RevenueRecognitionSystem.Domain.Interfaces;
using RevenueRecognitionSystem.Domain.Interfaces.Repositories;
using RevenueRecognitionSystem.Domain.Interfaces.Services;
using RevenueRecognitionSystem.Domain.Models.Client;
using RevenueRecognitionSystem.Infrastructure;

namespace RevenueRecognitionSystem.Application.Implementations
{
    public class ClientService : IClientService
    {
       private readonly ICompanyClientRepository _companyClientRepository;
        private readonly IIndividualClientRepository _individualClientRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ClientService(ICompanyClientRepository companyClientRepository, IUnitOfWork unitOfWork, IIndividualClientRepository individualClientRepository)
        {
            _companyClientRepository = companyClientRepository;
            _unitOfWork = unitOfWork;
            _individualClientRepository = individualClientRepository;

        }
        public bool AddCompanyClient(AddCompanyClientDTO dto)
        {
            CompanyClient.CreateNewCompanyClient(dto.Adress, dto.Email, dto.CompanyName, dto.KRS);
            _unitOfWork.Complete();
            return true;
        }

        public bool AddIndividualClient(AddIndividualClientDTO dto)
        {
            IndividualClient.CreateNewIndividualClient(dto.FirstName, dto.LastName, dto.PhoneNumber, dto.PESEL, dto.Adress, dto.Email);
            _unitOfWork.Complete();
            return true;
        }

        public bool DeleteIndividualClient(Guid id)
        {
            IndividualClient client = _individualClientRepository.GetById(id);
            
            if (client == null) 
            {
                return false;
            }
            client.Remove();
            _unitOfWork.Complete();
            return true;
        }

        public bool EditCompanyClient(EditCompanyClientDTO dto)
        {
            CompanyClient client = _companyClientRepository.GetById(dto.id);

            if (client == null)
            {
                return false;
            }
            client.Edit(dto.Adress, dto.Email, dto.CompanyName);
            _unitOfWork.Complete();
            return true;
        }

        public bool EditIndividualClient(EditIndividualClientDTO dto)
        {
            IndividualClient client = _individualClientRepository.GetById(dto.id);

            if (client == null)
            {
                return false;
            }
            client.Edit(dto.FirstName,dto.LastName, dto.PhoneNumber,  dto.Email,dto.Adress);
            _unitOfWork.Complete();
            return true;
        }
    }
}
