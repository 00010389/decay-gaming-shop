namespace decay_gaming_shop.Models
{
    public enum Category
    {
        Headphones,
        Mice,
        Keyboards,
        Microphones,
        Mousepads,
        Monitors,
        Chairs,
        Laptops,
    }
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public string ImageSrc { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }

        public ProductModel()
        {
            Id = -1;
            Name = "Nothing";
            Category = Category.Laptops;
            ImageSrc = "";
            Price = 0.00f;
            Description = "Nothing about";
            Rating = 0;
        }

        public ProductModel(int id, string name, Category category, string imageSrc, float price, string description, int rating)
        {
            Id = id;
            Name = name;
            Category = category;
            ImageSrc = imageSrc;
            Price = price;
            Description = description;
            Rating = rating;
        }
    }

}