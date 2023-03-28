using UmbrellaBiz.Models.Product;
using System;

namespace UmbrellaBiz.Models.AddingWeightItem
{
    public class AddingWeightItemModel : ModelBase
    {
        private int _productId;
        private ProductModel _product;
        private float _weight;
        private DateTime _date;

        public int Id { get; private set; }
        public int ProductId
        {
            get { return _productId; }
            set
            {
                _productId = value;
                OnPropertyChanged(nameof(ProductId));
            }
        }
        public ProductModel Product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged(nameof(Product));
            }
        }
        public float Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
    }
}
