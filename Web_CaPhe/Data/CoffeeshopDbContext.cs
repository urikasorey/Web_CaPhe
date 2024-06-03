using Web_CaPhe.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;    

namespace Web_CaPhe.Data
{
    public class CoffeeshopDbContext:IdentityDbContext
    {
            public CoffeeshopDbContext(DbContextOptions<CoffeeshopDbContext> options) :
           base(options)
            { 
            }
            public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartItem>ShoppingCartItems { get; set; }
        public DbSet<Order> Order {  get; set; }
        public DbSet<Contact> Contact { get; set; }    
        public DbSet<OrderDetail> OrderDetail { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Phở",
                Price = 25,
                Detail = "Phở is a traditional Vietnamese noodle soup consisting of broth, rice noodles, herbs, and meat, typically beef or chicken. The broth is simmered with various spices like star anise, cinnamon, and cloves, giving it a rich and aromatic flavor.",
                ImageUrl = "https://fantasea.vn/wp-content/uploads/2018/08/Ph%E1%BB%9F.jpg"
            },
                new Product
                {
                    Id = 2,
                    Name = "Bánh mì",
                    Price = 10,
                    Detail = "Bánh mì is a Vietnamese sandwich made with a baguette filled with various savory ingredients such as grilled pork, Vietnamese sausage, pickled vegetables, and fresh herbs.",
                    ImageUrl = "https://deliciousvietnam.net/wp-content/uploads/BanhMi_NgonVietnam01-1200x750.jpg"
                },
                new Product
                {
                    Id = 3,
                    Name = "Bún chả",
                    Price = 20,
                    Detail = "Bún chả is a Vietnamese dish of grilled pork served with rice vermicelli noodles, herbs, and a dipping sauce. It's typically eaten with fresh greens and pickled vegetables.",
                    ImageUrl = "https://hanoifreelocaltours.com/wp-content/uploads/2022/08/bun-cha6.jpg"
                },
                new Product
                {
                    Id = 4,
                    Name = "Cà phê sữa đá",
                    Price = 5,
                    Detail = "Cà phê sữa đá is a Vietnamese iced coffee made with strong drip coffee mixed with sweetened condensed milk and poured over ice. It's a popular and refreshing drink in Vietnam.",
                    ImageUrl = "https://vtv1.mediacdn.vn/thumb_w/650/2017/photo-1-1486340254837-1494033009271.jpg"
                },
                new Product
                {
                    Id = 5,
                    Name = "Gỏi cuốn",
                    Price = 15,
                    Detail = "Gỏi cuốn, also known as Vietnamese spring rolls or fresh spring rolls, are made with rice paper filled with shrimp, pork, herbs, rice vermicelli, and vegetables. They're often served with a dipping sauce.",
                    ImageUrl = "https://i.pinimg.com/originals/f7/57/6b/f7576bc886c91729b6853c4ae1fc91db.jpg"
                },
                new Product
                {
                    Id = 6,
                    Name = "Bánh xèo",
                    Price = 18,
                    Detail = "Bánh xèo is a Vietnamese savory pancake made from rice flour, water, turmeric powder, filled with shrimp, pork, bean sprouts, and then folded. It's often served with fresh herbs and lettuce for wrapping.",
                    ImageUrl = "https://foodisafourletterword.com/wp-content/uploads/2018/12/Banh_Xeo_Recipe_top.jpg"
                },
                new Product
                {
                    Id = 7,
                    Name = "Bánh cuốn",
                    Price = 12,
                    Detail = "Bánh cuốn is a Vietnamese dish of steamed rice rolls filled with minced pork, wood ear mushrooms, and shallots. It's served with dipping sauce and often accompanied by Vietnamese sausage and steamed bean sprouts.",
                    ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.YOzjjHom_B2-R3nRWoN7_wHaE9&pid=Api&P=0&h=220"
                },
                new Product
                {
                    Id = 8,
                    Name = "Bún riêu",
                    Price = 22,
                    Detail = "Bún riêu is a Vietnamese soup made with a tomato-based broth, crab or shrimp paste, tofu, and pork. It's served with rice vermicelli noodles, topped with crab meat, pork, and various herbs.",
                    ImageUrl = "https://seonkyounglongest.com/wp-content/uploads/2018/06/Bun-Rieu-07.jpg"
                },
                new Product
                {
                    Id = 9,
                    Name = "Cơm tấm",
                    Price = 17,
                    Detail = "Cơm tấm, also known as broken rice, is a Vietnamese dish made from fractured rice grains. It's served with various toppings such as grilled pork, shredded pork skin, and a side of pickled vegetables.",
                    ImageUrl = "https://statics.vinpearl.com/com-tam-ngon-o-sai-gon-0_1630563211.jpg"
                }
            );
        }

    }
}
