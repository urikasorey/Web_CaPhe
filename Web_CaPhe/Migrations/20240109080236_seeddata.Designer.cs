﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web_CaPhe.Data;

#nullable disable

namespace Web_CaPhe.Migrations
{
    [DbContext(typeof(CoffeeshopDbContext))]
    [Migration("20240109080236_seeddata")]
    partial class Seeddata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Web_CaPhe.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsTrendingProduct")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Phở",
                            Price = 25m,
                            Detail = "Phở is a traditional Vietnamese noodle soup consisting of broth, rice noodles, herbs, and meat, typically beef or chicken. The broth is simmered with various spices like star anise, cinnamon, and cloves, giving it a rich and aromatic flavor.",
                            ImageUrl = "https://fantasea.vn/wp-content/uploads/2018/08/Ph%E1%BB%9F.jpg",
                            IsTrendingProduct = true // Sản phẩm "Phở" đang được phổ biến
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bánh mì",
                            Price = 10m,
                            Detail = "Bánh mì is a Vietnamese sandwich made with a baguette filled with various savory ingredients such as grilled pork, Vietnamese sausage, pickled vegetables, and fresh herbs.",
                            ImageUrl = "https://deliciousvietnam.net/wp-content/uploads/BanhMi_NgonVietnam01-1200x750.jpg",
                            IsTrendingProduct = false
                        },
                        new
                        {
                            Id = 3,
                            Name = "Bún chả",
                            Price = 20m,
                            Detail = "Bún chả is a Vietnamese dish of grilled pork served with rice vermicelli noodles, herbs, and a dipping sauce. It's typically eaten with fresh greens and pickled vegetables.",
                            ImageUrl = "https://hanoifreelocaltours.com/wp-content/uploads/2022/08/bun-cha6.jpg",
                            IsTrendingProduct = false
                        },
                        new
                        {
                            Id = 4,
                            Name = "Cà phê sữa đá",
                            Price = 5m,
                            Detail = "Cà phê sữa đá is a Vietnamese iced coffee made with strong drip coffee mixed with sweetened condensed milk and poured over ice. It's a popular and refreshing drink in Vietnam.",
                            ImageUrl = "https://vtv1.mediacdn.vn/thumb_w/650/2017/photo-1-1486340254837-1494033009271.jpg",
                            IsTrendingProduct = false
                        },
                        new
                        {
                            Id = 5,
                            Detail = "Russian product",
                            ImageUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp",
                            IsTrendingProduct = false,
                            Name = "Russian",
                            Price = 25m
                        },
                        new
                        {
                            Id = 6,
                            Name = "Bánh xèo",
                            Price = 18,
                            Detail = "Bánh xèo is a Vietnamese savory pancake made from rice flour, water, turmeric powder, filled with shrimp, pork, bean sprouts, and then folded. It's often served with fresh herbs and lettuce for wrapping.",
                            ImageUrl = "https://foodisafourletterword.com/wp-content/uploads/2018/12/Banh_Xeo_Recipe_top.jpg",
                            IsTrendingProduct = false
                        },
                        new
                        {
                            Id = 7,
                            Name = "Bánh cuốn",
                            Price = 12,
                            Detail = "Bánh cuốn is a Vietnamese dish of steamed rice rolls filled with minced pork, wood ear mushrooms, and shallots. It's served with dipping sauce and often accompanied by Vietnamese sausage and steamed bean sprouts.",
                            ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.YOzjjHom_B2-R3nRWoN7_wHaE9&pid=Api&P=0&h=220",
                            IsTrendingProduct = false
                        },
                        new
                        {
                            Id = 8,
                            Name = "Bún riêu",
                            Price = 22,
                            Detail = "Bún riêu is a Vietnamese soup made with a tomato-based broth, crab or shrimp paste, tofu, and pork. It's served with rice vermicelli noodles, topped with crab meat, pork, and various herbs.",
                            ImageUrl = "https://seonkyounglongest.com/wp-content/uploads/2018/06/Bun-Rieu-07.jpg",
                            IsTrendingProduct = false
                        },
                        new
                        {
                            Id = 9,
                            Name = "Cơm tấm",
                            Price = 17,
                            Detail = "Cơm tấm, also known as broken rice, is a Vietnamese dish made from fractured rice grains. It's served with various toppings such as grilled pork, shredded pork skin, and a side of pickled vegetables.",
                            ImageUrl = "https://statics.vinpearl.com/com-tam-ngon-o-sai-gon-0_1630563211.jpg",
                            IsTrendingProduct = false
                        });
                });
#pragma warning restore 612, 618
        }
    }
}