using RevenueRecognitionSystem.Domain.DTOs.Contract;
using RevenueRecognitionSystem.Domain.DTOs.Subscription;
using RevenueRecognitionSystem.Domain.Exceptions;
using RevenueRecognitionSystem.Domain.Interfaces.Repositories;
using RevenueRecognitionSystem.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Tests
{
    public class SubscriptionServiceTest
    {
        ISubscriptionService _subscriptionService;
        public SubscriptionServiceTest(ISubscriptionService _subscriptionService)
        {
            _subscriptionService = _subscriptionService;
        }
        [Fact]
        public void BuySubscription_Throws_Incorrect_Subscription_Period_Exception()
        {
            //Arrange
            BuySubscriptionDTO testRequest = new BuySubscriptionDTO();

            //Act

            var ex = Assert.Throws<IncorrectSubscriptionPeriodException>(() => _subscriptionService.BuySubscription(testRequest));

            //Assert
            Assert.IsType<IncorrectSubscriptionPeriodException>(ex);
        }

        [Fact]
        public void BuySubscription_Throws_Subscription_Cancelled_Exception()
        {
            //Arrange
            BuySubscriptionDTO testRequest = new BuySubscriptionDTO();

            //Act

            var ex = Assert.Throws<SubscriptionCancelledException>(() => _subscriptionService.BuySubscription(testRequest));

            //Assert
            Assert.IsType<SubscriptionCancelledException>(ex);
        }

        [Fact]
        public void BuySubscription_Throws_Subscription_Already_Paid_Exception()
        {
            //Arrange
            BuySubscriptionDTO testRequest = new BuySubscriptionDTO();

            //Act

            var ex = Assert.Throws<SubscriptionAlreadyPaid>(() => _subscriptionService.BuySubscription(testRequest));

            //Assert
            Assert.IsType<SubscriptionAlreadyPaid>(ex);
        }

    }
}
