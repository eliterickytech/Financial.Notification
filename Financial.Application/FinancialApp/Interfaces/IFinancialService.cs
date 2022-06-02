using Financial.Application.FinancialApp.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Application.FinancialApp.Interfaces
{
    public interface IFinancialService
    {
        Task NotifyCustomerWithOrder(List<Customer> customer);
    }
}
