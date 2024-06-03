using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_CaPhe.Migrations
{
    /// <inheritdoc />
    public partial class contacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false), 
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactId);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://deliciousvietnam.net/wp-content/uploads/BanhMi_NgonVietnam01-1200x750.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://hanoifreelocaltours.com/wp-content/uploads/2022/08/bun-cha6.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://vtv1.mediacdn.vn/thumb_w/650/2017/photo-1-1486340254837-1494033009271.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://i.pinimg.com/originals/f7/57/6b/f7576bc886c91729b6853c4ae1fc91db.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://foodisafourletterword.com/wp-content/uploads/2018/12/Banh_Xeo_Recipe_top.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://tse2.mm.bing.net/th?id=OIP.YOzjjHom_B2-R3nRWoN7_wHaE9&pid=Api&P=0&h=220");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://seonkyounglongest.com/wp-content/uploads/2018/06/Bun-Rieu-07.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://statics.vinpearl.com/com-tam-ngon-o-sai-gon-0_1630563211.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/2/23/Banh_mi_thit_nga_baguette.jpg/800px-Banh_mi_thit_nga_baguette.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8d/B%C3%BAn_ch%E1%BA%A3.jpg/800px-B%C3%BAn_ch%E1%BA%A3.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/4/46/C%C3%A0_ph%C3%AA_s%E1%BB%AFa_%C4%91%C3%A1_h%E1%BB%93ng_h%C3%B2a.jpg/800px-C%C3%A0_ph%C3%AA_s%E1%BB%AFa_%C4%91%C3%A1_h%E1%BB%93ng_h%C3%B2a.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Vietnamese-rolls.jpg/800px-Vietnamese-rolls.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/0/03/B%C3%A1nh_x%C3%A8o_t%C6%B0%C6%A1i_Nam_%C4%90%E1%BB%8Bnh.jpg/800px-B%C3%A1nh_x%C3%A8o_t%C6%B0%C6%A1i_Nam_%C4%90%E1%BB%8Bnh.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a3/B%C3%A1nh_cu%E1%BB%91n_h%C3%A0ng_b%C3%A0_%C4%91%E1%BB%99ng.jpg/800px-B%C3%A1nh_cu%E1%BB%91n_h%C3%A0ng_b%C3%A0_%C4%91%E1%BB%99ng.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2a/B%C3%BAn_ri%C3%AAu_cua_t%C3%B4m.jpg/800px-B%C3%BAn_ri%C3%AAu_cua_t%C3%B4m.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/9/99/C%C6%A1m_t%E1%BA%A5m_s%C3%A0i_g%C3%B2n.JPG/800px-C%C6%A1m_t%E1%BA%A5m_s%C3%A0i_g%C3%B2n.JPG");
        }
    }
}
