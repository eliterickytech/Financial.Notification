using Financial.Application.FinancialApp.Input;
using Financial.Application.Shared;
using Flunt.Br;
using System.Collections.Generic;

namespace Financial.Application.FinancialApp.Contracts
{
    public class CustomersContract : BaseContract<List<Customer>>
    {
        public CustomersContract(List<Customer> customers)
        {
            Validate(customers);
        }

        protected override void Validate(List<Customer> customers)
        {
            foreach (var customer in customers)
            {
                AddNotifications(new Contract()
                    .IsLowerOrEqualsThan(customer.CodeCommerce.Value, 0, "The CodeCommerce field must be greater than 0"));
            }
        }
    }
}
