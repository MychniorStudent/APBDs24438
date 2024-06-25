using RevenueRecognitionSystem.Domain.DTOs.Contract;
using RevenueRecognitionSystem.Domain.Exceptions;
using RevenueRecognitionSystem.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Tests
{
    public class ContractServiceTest
    {
        IContractService _contractService;
        public ContractServiceTest(IContractService contractService)
        {
            _contractService = contractService;
        }

        [Fact]
        public void CreateContract_Throws_Client_Already_Has_System_Exception()
        {
            //Arrange
           CreateContractDTO testRequest = new CreateContractDTO();

            //Act

            var ex = Assert.Throws<ClientAlreadyHasSystemException>(() => _contractService.CreateContract(testRequest));

            //Assert
            Assert.IsType<ClientAlreadyHasSystemException>(ex);
        }

        [Fact]
        public void CreateContract_Throws_Contract_Range_Incorrect_Period_Exception()
        {
            //Arrange
            CreateContractDTO testRequest = new CreateContractDTO();

            //Act

            var ex = Assert.Throws<ContractRangeIncorrectPeriodException>(() => _contractService.CreateContract(testRequest));

            //Assert
            Assert.IsType<ContractRangeIncorrectPeriodException>(ex);
        }
        [Fact]
        public void PayContract_Throws_Contract_Already_Finalized_Exception()
        {
            //Arrange
            PayForContractDTO testRequest = new PayForContractDTO();

            //Act

            var ex = Assert.Throws<ContractAlreadyFinalized>(() => _contractService.PayForContract(testRequest));

            //Assert
            Assert.IsType<ContractAlreadyFinalized>(ex);
        }
        [Fact]
        public void PayContract_Throws_Contract_Already_Cancelled_Exception()
        {
            //Arrange
            PayForContractDTO testRequest = new PayForContractDTO();

            //Act

            var ex = Assert.Throws<ContractAlreadyCancelled>(() => _contractService.PayForContract(testRequest));

            //Assert
            Assert.IsType<ContractAlreadyCancelled>(ex);
        }
        [Fact]
        public void PayContract_Throws_Payment_Time_Expired_Exception()
        {
            //Arrange
            PayForContractDTO testRequest = new PayForContractDTO();

            //Act

            var ex = Assert.Throws<PaymentTimeExpiredException>(() => _contractService.PayForContract(testRequest));

            //Assert
            Assert.IsType<PaymentTimeExpiredException>(ex);
        }

        [Fact]
        public void PayContract_Throws_Contract_Overpaid_Exception()
        {
            //Arrange
            PayForContractDTO testRequest = new PayForContractDTO();

            //Act

            var ex = Assert.Throws<ContractOverpaidException>(() => _contractService.PayForContract(testRequest));

            //Assert
            Assert.IsType<ContractOverpaidException>(ex);
        }
    }
}
