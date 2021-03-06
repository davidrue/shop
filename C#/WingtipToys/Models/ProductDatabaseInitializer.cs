﻿using System.Collections.Generic;
using System.Data.Entity;

namespace WingtipToys.Models
{
  public class ProductDatabaseInitializer : DropCreateDatabaseAlways<ProductContext>  //DropCreateDatabaseIfModelChanges<ProductContext>
    {
        public ProductDatabaseInitializer()
        {
            
        }
    protected override void Seed(ProductContext context) 
        {
  
      GetCategories().ForEach(c => context.Categories.Add(c));
      GetProducts().ForEach(p => context.Products.Add(p));
    }

    private static List<Category> GetCategories()
    {
      var categories = new List<Category> {
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Mainboards"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Processors"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "GraphicsCards"
                },
                
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "HardDrives"
                },
                 new Category
                {
                    CategoryID = 5,
                    CategoryName = "Cases"
                },
                new Category
                {
                    CategoryID = 6,
                    CategoryName = "KeyboardsAndMouses"
                }
            };

      return categories;
    }

    private static List<Product> GetProducts()
    {
            var products = new List<Product> {
                new Product
                {
                    ProductID = 1,
                    ProductName = "Gigabyte 990FX-Gaming (only for Intel processors)",
                    Description = "This Mainboard is like no other Mainboard.",
                    ImagePath="gigabyte990fx-gaming.png",
                    UnitPrice = 179.99,
                    CategoryID = 1,
                    isIntel = true,
                    isAmd = false
                },
                new Product
                {
                    ProductID = 2,
                    ProductName = "MSI Z270 Gaming M5 (only for Amd processors)",
                    Description = "There is no Mainboard as stylish as this one.",
                    ImagePath="msiz270gamingm5.png",
                    UnitPrice = 129.99,
                    CategoryID = 1,
                    isIntel = false,
                    isAmd = true
                },
                new Product
                {
                    ProductID = 3,
                    ProductName = "ASRock H81M-VG4 (for all brands)",
                    Description = "Do not care about the brand of your processor. This mainboard takes them all!",
                    ImagePath="ASRock.png",
                    UnitPrice = 149.99,
                    CategoryID = 1,
                    isIntel = true,
                    isAmd = true
                },
                new Product
                {
                    ProductID = 4,
                    ProductName = "Intel i3 Core",
                    Description = "A processor with a very low power consumption.",
                    ImagePath="inteli3.png",
                    UnitPrice = 149.95,
                    CategoryID = 2,
                    isIntel = true,
                    isAmd = false
               },
                new Product 
                {
                    ProductID = 5,
                      ProductName = "Intel i5 Core",
                    Description = "The processor with balance between power consumption and computing power.",
                    ImagePath="inteli5.png",
                    UnitPrice = 199.95,
                     CategoryID = 2,
                    isIntel = true,
                    isAmd = false
               },
                new Product
                {
                    ProductID = 6,
                    ProductName = "Intel i7 Core",
                    Description = "The processor with the most computing power.",
                    ImagePath="inteli7.png",
                    UnitPrice = 249.95,
                    CategoryID = 2,
                    isIntel = true,
                    isAmd = false
                },
                new Product
                {
                    ProductID = 7,
                    ProductName = "AMD Phenom II X6",
                    Description = "The processor for the low budget.",
                    ImagePath="amdx6.png",
                    UnitPrice = 119.95,
                    CategoryID = 2,
                    isIntel = false,
                    isAmd = true
                },
                new Product
                {
                    ProductID = 8,
                    ProductName = "AMD 7860k",
                    Description = "The high end AMD processor.",
                    ImagePath="amd7860k.png",
                    UnitPrice = 189.95,
                    CategoryID = 2,
                    isIntel = false,
                    isAmd = true
                },
                new Product
                {
                    ProductID = 9,
                    ProductName = "Gigabyte GTX 1080",
                    Description = "This is the powerful Gigabyte GTX 1080. It is so powerful.",
                    ImagePath = "gigabytegtx1080.png",
                    UnitPrice = 155.95,
                    CategoryID = 3
                },
                new Product
                {
                    ProductID = 10,
                    ProductName = "NVidia NVS 810",
                    Description = "This is the brilliant NVidia NVS 810.",
                    ImagePath="nvidianvs810.png",
                    UnitPrice = 169.95,
                    CategoryID = 3
                },
                new Product
                {
                    ProductID = 11,
                    ProductName = "Asus GR8 II",
                    Description = "This is some Asus Graphic Card. It is really awesome. Really, trust me.",
                    ImagePath="asus.png",
                    UnitPrice = 199.95,
                    CategoryID = 3
                },
                new Product
                {
                    ProductID = 12,
                    ProductName = "Samsung NVMe SSD960 Pro",
                    Description = "This Hard Drive as such an outstanding performance. You would not believe it.",
                    ImagePath="samsungnvmessd960pro.png",
                    UnitPrice = 139.99,
                    CategoryID = 4
                },
                new Product
                {
                    ProductID = 13,
                    ProductName = "Western Digital Blue 1TB",
                    Description = "So much storage. Wow.",
                    ImagePath="westerndigitalblue.png",
                    UnitPrice = 129.99,
                    CategoryID = 4
                },
                 new Product
                {
                    ProductID = 14,
                    ProductName = "ATX Full-Tower",
                    Description = "So big. So awesome.",
                    ImagePath="ATX Full-Tower.png",
                    UnitPrice = 59.99,
                    CategoryID = 5
                },
                  new Product
                {
                    ProductID = 15,
                    ProductName = "PCCG Infinity 1080Ti Gaming",
                    Description = "Everyone will be totaly jealous.",
                    ImagePath="PCCGInfinity1080TiGaming.png",
                    UnitPrice = 64.99,
                    CategoryID = 5
                },

                   new Product
                {
                    ProductID = 16,
                    ProductName = "Logitech Keyboard",
                    Description = "It has great ergonomics.",
                    ImagePath="logitech.png",
                    UnitPrice = 89.99,
                    CategoryID = 6
                },
                    new Product
                {
                    ProductID = 17,
                    ProductName = "Logitech Mouse",
                    Description = "Every click has its own feeling. You have to feel it yourself!",
                    ImagePath="LogitechM325.png",
                    UnitPrice = 34.99,
                    CategoryID = 6
                },
                      new Product
                {
                    ProductID = 18,
                    ProductName = "Microsoft Super Bundle Keyboard and Mouse",
                    Description = "Just priceless!",
                    ImagePath="MicrosoftComfortBoard.png",
                    UnitPrice = 179.99,
                    CategoryID = 6
                }

            };

      return products;
    }
  }
}