using MyBusiness.Data;
using MyBusiness.Models.Customer;

namespace MyBusiness.Services
{
    public class CustomerModelService
    {
        public static void AddCustomer(CustomerModel customer)
        {
            using (var context = new ApplicationContext())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }
    }
}
