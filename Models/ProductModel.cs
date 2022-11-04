using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string Name { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public string ImageSrc { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
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