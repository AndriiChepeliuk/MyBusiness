using UmbrellaBiz.Data;
using UmbrellaBiz.Models.Customer;

namespace UmbrellaBiz.Services
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
