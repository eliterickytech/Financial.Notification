using Financial.Application.FinancialApp.Input;
using Financial.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Application.FinancialApp.Mapping
{
    public static class CustomerMapping
    {
        public static List<CustomerEvents> Map(this List<Customer> customers)
        {
            if (customers is null) return default;

            List<CustomerEvents> customerEvents = new List<CustomerEvents>();
            customers.ForEach(x =>
            {
                customerEvents.Add(new CustomerEvents() 
                { 
                    CodeCommerce = x.CodeCommerce,
                    TypeOfCustomer = x.TypeOfCustomer
                });
            });
            return customerEvents;
        }
    }
}
