using Financial.Application.FinancialApp.Input;
using Financial.Application.FinancialApp.Interfaces;
using Financial.Application.Shared.Interfaces;
using Financial.Notification.Controller;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Financial.Notification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegrationRMController : BaseController
    {
        private readonly IFinancialService _financialService;
        private readonly IPublishEndpoint _publisher;

        public IntegrationRMController(IPublishEndpoint publishEndpoint, IBaseNotification baseNotification, IFinancialService financialService) : base(baseNotification)
        {
            _financialService = financialService;
            _publisher = publishEndpoint;

        }

        [HttpPost]
        [Route("customers")]
        public async Task<IActionResult> PostAsync(List<Customer> customers)
        {

            await _financialService.NotifyCustomerWithOrder(customers);
            return CreatedOrBadRequest(string.Empty);

        }
    }
}
