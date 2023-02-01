using MyBusiness.Data;

namespace MyBusiness.ViewModels
{
    public class AllProductsViewModel : ViewModelBase
    {
        private ApplicationContext _context;

        public AllProductsViewModel()
        {
            _context = new ApplicationContext();
        }
    }
}
