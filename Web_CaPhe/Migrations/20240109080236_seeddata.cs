using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web_CaPhe.Migrations
{
    /// <inheritdoc />
    public partial class Seeddata : Migration
    {
        /// <inheritdoc /> 
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Detail", "ImageUrl", "IsTrendingProduct", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Phở is a traditional Vietnamese noodle soup consisting of broth, rice noodles, herbs, and meat, typically beef or chicken. The broth is simmered with various spices like star anise, cinnamon, and cloves, giving it a rich and aromatic flavor.", "https://fantasea.vn/wp-content/uploads/2018/08/Ph%E1%BB%9F.jpg", true, "Phở", 25m },
                    { 2, "Bánh mì is a Vietnamese sandwich made with a baguette filled with various savory ingredients such as grilled pork, Vietnamese sausage, pickled vegetables, and fresh herbs.", "https://deliciousvietnam.net/wp-content/uploads/BanhMi_NgonVietnam01-1200x750.jpg", false, "Bánh mì", 10m },
                    { 3, "Bún chả is a Vietnamese dish of grilled pork served with rice vermicelli noodles, herbs, and a dipping sauce. It's typically eaten with fresh greens and pickled vegetables.", "https://hanoifreelocaltours.com/wp-content/uploads/2022/08/bun-cha6.jpg", false, "Bún chả", 20m },
                    { 4, "Cà phê sữa đá is a Vietnamese iced coffee made with strong drip coffee mixed with sweetened condensed milk and poured over ice. It's a popular and refreshing drink in Vietnam.", "https://vtv1.mediacdn.vn/thumb_w/650/2017/photo-1-1486340254837-1494033009271.jpg", false, "Cà phê sữa đá", 5m },
                    { 5, "Gỏi cuốn, also known as Vietnamese spring rolls or fresh spring rolls, are made with rice paper filled with shrimp, pork, herbs, rice vermicelli, and vegetables. They're often served with a dipping sauce.", "https://i.pinimg.com/originals/f7/57/6b/f7576bc886c91729b6853c4ae1fc91db.jpg", false, "Gỏi cuốn", 15m },
                    { 6, "Bánh xèo is a Vietnamese savory pancake made from rice flour, water, turmeric powder, filled with shrimp, pork, bean sprouts, and then folded. It's often served with fresh herbs and lettuce for wrapping.", "https://foodisafourletterword.com/wp-content/uploads/2018/12/Banh_Xeo_Recipe_top.jpg", false, "Bánh xèo", 18m },
                    { 7, "Bánh cuốn is a Vietnamese dish of steamed rice rolls filled with minced pork, wood ear mushrooms, and shallots. It's served with dipping sauce and often accompanied by Vietnamese sausage and steamed bean sprouts.", "https://tse2.mm.bing.net/th?id=OIP.YOzjjHom_B2-R3nRWoN7_wHaE9&pid=Api&P=0&h=220", false, "Bánh cuốn", 12m },
                    { 8, "Bún riêu is a Vietnamese soup made with a tomato-based broth, crab or shrimp paste, tofu, and pork. It's served with rice vermicelli noodles, topped with crab meat, pork, and various herbs.", "https://seonkyounglongest.com/wp-content/uploads/2018/06/Bun-Rieu-07.jpg", false, "Bún riêu", 22m },
                    { 9, "Cơm tấm, also known as broken rice, is a Vietnamese dish made from fractured rice grains. It's served with various toppings such as grilled pork, shredded pork skin, and a side of pickled vegetables.", "https://statics.vinpearl.com/com-tam-ngon-o-sai-gon-0_1630563211.jpg", false, "Cơm tấm", 17m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
