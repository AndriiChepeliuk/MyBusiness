using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
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

        public static List<CustomerModel> GetAllCustomers()
        {
            using (var context = new ApplicationContext())
            {
                var customers = context.Customers.OrderBy(x => x.Name).ToList();

                foreach (var customer in customers)
                {
                    MemoryStream memoryStream = new MemoryStream(customer.AvatarByteCode);
                    customer.Avatar = new BitmapImage();
                    customer.Avatar.BeginInit();
                    customer.Avatar.StreamSource = memoryStream;
                    customer.Avatar.EndInit();
                }

                return customers;
            }
        }
    }
}
