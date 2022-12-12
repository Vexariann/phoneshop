namespace Phoneshop.Domain.Models
{
    // <summary>
    // Create class Phone which defines all of the values that need to be set for a new Phone object
    // </summary>
    public class Phone
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string FullName => $"{Brand?.BrandName} - {Type}";
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public decimal PriceNoVAT => Math.Round((Price / 1.21m), 2);
        public string Description { get; set; }

        public Brand Brand { get; set; }
        public int BrandID { get; set; }
    }
}