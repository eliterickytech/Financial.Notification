using Financial.Application.FinancialApp.Input;
using Financial.Application.FinancialApp.Interfaces;
using Financial.Application.FinancialApp.Mapping;
using Financial.Application.FinancialApp.Contracts;
using Financial.Domain.Events;
using MassTransit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Financial.Application.Shared.Interfaces;

namespace Financial.Application.FinancialApp
{
    public class FinancialService : IFinancialService
    {
        private readonly IPublishEndpoint _publisher;
        private readonly IBaseNotification _baseNotification;

        public FinancialService(IBaseNotification baseNotification, IPublishEndpoint publishEndpoint)
        {
            _publisher = publishEndpoint;
            _baseNotification = baseNotification;
        }

        public async Task NotifyCustomerWithOrder(List<Customer> customers)
        {
            var customersContract = new CustomersContract(customers);

            if (!customersContract.IsValid)
            {
                _baseNotification.AddNotifications(customersContract.Notifications);
                return;
            }

            var customerEvents = customers?.Map();
            await _publisher.Publish<CustomerEvents>(customerEvents);
        }
    }
}
