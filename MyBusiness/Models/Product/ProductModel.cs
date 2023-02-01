namespace MyBusiness.Models.Product
{
    public class ProductModel : ModelBase
    {
        private string? name;
        private string? category;
        private float weight;
        private decimal price;

        public int Id { get; set; }
        public string Name 
        { 
            get { return name; } 
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged(nameof(Category));
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
        public decimal Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
    }
}
