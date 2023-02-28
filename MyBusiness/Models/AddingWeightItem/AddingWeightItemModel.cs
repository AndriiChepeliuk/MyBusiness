using MyBusiness.Models.Customer;
using MyBusiness.Models.Product;
using System;

namespace MyBusiness.Models.AddingWeightItem
{
    public class AddingWeightItemModel : ModelBase
    {
        private int productId;
        private ProductModel product;
        private float weight;
        private DateTime date;

        public int Id { get; private set; }
        public int ProductId
        {
            get { return productId; }
            set
            {
                productId = value;
                OnPropertyChanged(nameof(ProductId));
            }
        }
        public ProductModel Product
        {
            get { return product; }
            set
            {
                product = value;
                OnPropertyChanged(nameof(Product));
            }
        }
        public float Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
    }
}
