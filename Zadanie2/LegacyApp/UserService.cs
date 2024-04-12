using LegacyApp.Implementations;
using LegacyApp.Interfaces;
using LegacyApp.Model;
using System;

namespace LegacyApp
{
    public class UserService //: IUserService
    {
        IUserCreditService _userCreditService;
        IValidator _validator;
        IClientRepository _clientRepository;
        public UserService()
        {  
            _validator = new Validator();
            _userCreditService = new UserCreditService();
            _clientRepository = new ClientRepository(_userCreditService);
        }
        public UserService(IValidator userValidator, IUserCreditService creditService, IClientRepository clientRepository)
        {
            _validator = userValidator;
            _userCreditService = creditService;
            _clientRepository = clientRepository;
        }
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if(!_validator.isNameCorrect(firstName) || !_validator.isNameCorrect(lastName))
            {
                return false;
            }

            if (!_validator.isEmailValid(email))
            {
                return false;
            }

            if (!_validator.isOldEnough(dateOfBirth))
            {
                return false;
            }

            Client client = _clientRepository.GetById(clientId);
            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            _clientRepository.setCreditLimitForUserByClient(user, client);

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
