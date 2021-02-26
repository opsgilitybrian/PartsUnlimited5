using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PartsUnlimited5.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartsUnlimited5.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CommunityPost> CommunityPosts { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Raincheck> Rainchecks { get; set; }
        public DbSet<RaincheckProduct> RaincheckProducts { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreProduct> StoreProducts { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        private const string SYSTEM_ADMIN_ID = "e1367305-f547-43e0-9af3-3e5e0861844b";
        private const string ADMIN_ROLE_ID = "e60bc581-bc55-41ca-9ae6-ace692e15ae5";
        private const string CUSTOMER_ROLE_ID = "39ff8dfb-95d0-4ab5-b32b-3b85d26508c0";
        private DateTime seedDateTime = new DateTime(2021, 01, 01);
        private const string WEB_STORE = "WebStore";
        private const string STORE_1 = "Store1";
        private const string STORE_2 = "Store2";

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedUsers(modelBuilder);
            SeedRoles(modelBuilder);
            SeedUserRoles(modelBuilder);

            SeedProducts(modelBuilder);
            SeedCategories(modelBuilder);

            SeedStores(modelBuilder);
            //SeedStoreProducts(modelBuilder);
        }

        private void SeedUsers(ModelBuilder modelBuilder)
        {
            //var ph = new PasswordHasher<IdentityUser>();
            //user.PasswordHash = ph.HashPassword(user, "seeduser#123!");

            //create the admin user
            var user = new IdentityUser
            {
                Id = SYSTEM_ADMIN_ID,
                Email = "seedadministrator@example.com",
                NormalizedEmail = "SEEDADMINISTRATOR@EXAMPLE.COM",
                EmailConfirmed = true,
                UserName = "SeedAdministrator",
                NormalizedUserName = "SEEDADMINISTRATOR",
                TwoFactorEnabled = false,
                SecurityStamp = string.Empty,
                PasswordHash = "AQAAAAEAACcQAAAAEB9FIk0z5Ci79JEGK06lndZgQ9Ago2FxFkN4MlVZQD1Di+6zFcuEu/KiINwnmVrspw==",
                AccessFailedCount = 0,
                ConcurrencyStamp = "1",
                LockoutEnabled = true,
                LockoutEnd = null,
                PhoneNumber = "999-999-9999",
                PhoneNumberConfirmed = true
            };

            modelBuilder.Entity<IdentityUser>().HasData(user);
        }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            //create the admin role
            var adminRole = new IdentityRole()
            {
                Name = "SystemAdmin",
                NormalizedName = "SYSTEMADMIN",
                Id = ADMIN_ROLE_ID,
                ConcurrencyStamp = "1"
            };

            modelBuilder.Entity<IdentityRole>().HasData(adminRole);

            //create the customer role
            var customerRole = new IdentityRole()
            {
                Name = "GeneralCustomer",
                NormalizedName = "GENERALCUSTOMER",
                Id = CUSTOMER_ROLE_ID,
                ConcurrencyStamp = "2"
            };

            modelBuilder.Entity<IdentityRole>().HasData(customerRole);
        }

        private void SeedUserRoles(ModelBuilder modelBuilder)
        {
            var iur = new IdentityUserRole<string>()
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = SYSTEM_ADMIN_ID
            };

            //set user role to admin
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(iur);
        }
        private void SeedProducts(ModelBuilder modelBuilder)
        {
            var brakeProducts = GetBrakes();
            var lightingProducts = GetLights();
            var wheelsAndTires = GetTires();
            var batteries = GetBatteries();
            var oils = GetOils();

            modelBuilder.Entity<Product>().HasData(brakeProducts);
            modelBuilder.Entity<Product>().HasData(lightingProducts);
            modelBuilder.Entity<Product>().HasData(wheelsAndTires);
            modelBuilder.Entity<Product>().HasData(batteries);
            modelBuilder.Entity<Product>().HasData(oils);
        }

        private void SeedCategories(ModelBuilder modelBuilder)
        {
            var brakeCategory = new Category()
            {
                Id = 1,
                CreatedByUserId = SYSTEM_ADMIN_ID,
                CreatedDate = seedDateTime,
                Description = "Brakes for your buggy",
                IsActive = true,
                Name = "Brakes"
            };

            var lightingCategory = new Category()
            {
                Id = 2,
                CreatedByUserId = SYSTEM_ADMIN_ID,
                CreatedDate = seedDateTime,
                Description = "Lighting for your buggy",
                IsActive = true,
                Name = "Lighting"
            };

            var wheelsCategory = new Category()
            {
                Id = 3,
                CreatedByUserId = SYSTEM_ADMIN_ID,
                CreatedDate = seedDateTime,
                Description = "Wheels and Tires for your buggy",
                IsActive = true,
                Name = "WheelsAndTires"
            };

            var batteriesCategory = new Category()
            {
                Id = 4,
                CreatedByUserId = SYSTEM_ADMIN_ID,
                CreatedDate = seedDateTime,
                Description = "Batteries for your buggy",
                IsActive = true,
                Name = "Batteries"
            };

            var oilsCategory = new Category()
            {
                Id = 5,
                CreatedByUserId = SYSTEM_ADMIN_ID,
                CreatedDate = seedDateTime,
                Description = "Oil for your buggy",
                IsActive = true,
                Name = "Oil"
            };

            modelBuilder.Entity<Category>().HasData(brakeCategory);
            modelBuilder.Entity<Category>().HasData(lightingCategory);
            modelBuilder.Entity<Category>().HasData(wheelsCategory);
            modelBuilder.Entity<Category>().HasData(batteriesCategory);
            modelBuilder.Entity<Category>().HasData(oilsCategory);
        }

        

        private List<Product> GetBrakes()
        {
            var products = new List<Product>();
            products.Add(new Product
            {
                Id = 1,
                SkuNumber = "BRA-0001",
                CreatedDate = seedDateTime,
                Title = "Disk and Pad Combo",
                Price = 25.99,
                SalePrice = 25.99,
                ProductArtUrl = "product_brakes_disk-pad-combo.jpg",
                ProductDetails = "{ \"Disk Design\" : \"Cross Drill Slotted\", \" Pad Material\" : \"Ceramic\", \"Construction\" : \"Vented Rotor\", \"Diameter\" : \"10.3 in.\", \"Finish\" : \"Silver Zinc Plated\", \"Hat Finish\" : \"Silver Zinc Plated\", \"Material\" : \"Cast Iron\" }",
                Description = "Our brake disks and pads perform the best together. Better stopping distances without locking up, reduced rust and dusk.",
                LeadTime = 6,
                CreatedByUserId = SYSTEM_ADMIN_ID
            });
            products.Add(new Product
            {
                Id = 2,
                SkuNumber = "BRA-0002",
                CreatedDate = seedDateTime,
                Title = "Brake Rotor",
                Price = 18.99,
                SalePrice = 18.99,
                ProductArtUrl = "product_brakes_disc.jpg",
                ProductDetails = "{ \"Disk Design\" : \"Cross Drill Slotted\",  \"Construction\" : \"Vented Rotor\", \"Diameter\" : \"10.3 in.\", \"Finish\" : \"Silver Zinc Plated\", \"Hat Finish\" : \"Black E-coating\",  \"Material\" : \"Cast Iron\" }",
                Description = "Our Brake Rotor Performs well in wet conditions with a smooth responsive feel. Machined to a high tolerance to ensure all of our Brake Rotors are safe and reliable.",
                LeadTime = 0,
                CreatedByUserId = SYSTEM_ADMIN_ID
            });
            products.Add(new Product
            {
                Id = 3,
                SkuNumber = "BRA-0003",
                CreatedDate = seedDateTime,
                Title = "Brake Disk and Calipers",
                Price = 43.99,
                SalePrice = 43.99,
                ProductArtUrl = "product_brakes_disc-calipers-red.jpg",
                ProductDetails = "{\"Disk Design\" : \"Cross Drill Slotted\", \" Pad Material\" : \"Carbon Ceramic\",  \"Construction\" : \"Vented Rotor\", \"Diameter\" : \"11.3 in.\", \"Bolt Pattern\": \"6 x 5.31 in.\", \"Finish\" : \"Silver Zinc Plated\",  \"Material\" : \"Carbon Alloy\", \"Includes Brake Pads\" : \"Yes\" }",
                Description = "Upgrading your brakes can increase stopping power, reduce dust and noise. Our Disk Calipers exceed factory specification for the best performance.",
                LeadTime = 0,
                CreatedByUserId = SYSTEM_ADMIN_ID
            });
            return products;
        }

        private List<Product> GetLights()
        {
            var products = new List<Product>();
            products.Add(new Product
            {
                Id = 4,
                SkuNumber = "LIG-0001",
                CreatedDate = seedDateTime,
                Title = "Halogen Headlights (2 Pack)",
                Price = 38.99,
                SalePrice = 38.99,
                ProductArtUrl = "product_lighting_headlight.jpg",
                ProductDetails = "{ \"Light Source\" : \"Halogen\", \"Assembly Required\": \"Yes\", \"Color\" : \"Clear\", \"Interior\" : \"Chrome\", \"Beam\": \"low and high\", \"Wiring harness included\" : \"Yes\", \"Bulbs Included\" : \"No\",  \"Includes Parking Signal\" : \"Yes\"}",
                Description = "Our Halogen Headlights are made to fit majority of vehicles with our  universal fitting mold. Product requires some assembly and includes light bulbs.",
                LeadTime = 0,
                CreatedByUserId = SYSTEM_ADMIN_ID
            });
            products.Add(new Product
            {
                Id = 5,
                SkuNumber = "LIG-0002",
                CreatedDate = seedDateTime,
                Title = "Bugeye Headlights (2 Pack)",
                Price = 48.99,
                SalePrice = 48.99,
                ProductArtUrl = "product_lighting_bugeye-headlight.jpg",
                ProductDetails = "{ \"Light Source\" : \"Halogen\", \"Assembly Required\": \"Yes\", \"Color\" : \"Clear\", \"Interior\" : \"Chrome\", \"Beam\": \"low and high\", \"Wiring harness included\" : \"No\", \"Bulbs Included\" : \"Yes\",  \"Includes Parking Signal\" : \"Yes\"}",
                Description = "Our Bugeye Headlights use Halogen light bulbs are made to fit into a standard Bugeye slot. Product requires some assembly and includes light bulbs.",
                LeadTime = 0,
                CreatedByUserId = SYSTEM_ADMIN_ID
            });
            products.Add(new Product
            {
                Id = 6,
                SkuNumber = "LIG-0003",
                CreatedDate = seedDateTime,
                Title = "Turn Signal Light Bulb",
                Price = 6.49,
                SalePrice = 6.49,
                ProductArtUrl = "product_lighting_lightbulb.jpg",
                ProductDetails = "{ \"Color\" : \"Clear\", \"Fit\" : \"Universal\", \"Wattage\" : \"30 Watts\", \"Includes Socket\" : \"Yes\"}",
                Description = " Clear bulb that with a universal fitting for all headlights/taillights.  Simple Installation, low wattage and a clear light for optimal visibility and efficiency.",
                LeadTime = 0,
                CreatedByUserId = SYSTEM_ADMIN_ID
            });
            return products;
        }

        private List<Product> GetTires()
        {
            var products = new List<Product>();
            products.Add(new Product
            {
                Id = 7,
                SkuNumber = "WHE-0001",
                CreatedDate = seedDateTime,
                Title = "Matte Finish Rim",
                Price = 75.99,
                SalePrice = 75.99,
                ProductArtUrl = "product_wheel_rim.jpg",
                ProductDetails = "{ \"Material\" : \"Aluminum alloy\",  \"Design\" : \"Spoke\", \"Spokes\" : \"9\",  \"Number of Lugs\" : \"4\", \"Wheel Diameter\" : \"17 in.\", \"Color\" : \"Black\", \"Finish\" : \"Matte\" } ",
                Description = "A Parts Unlimited favorite, the Matte Finish Rim is affordable low profile style. Fits all low profile tires.",
                LeadTime = 0,
                CreatedByUserId = SYSTEM_ADMIN_ID
            });
            products.Add(new Product
            {
                Id = 8,
                SkuNumber = "WHE-0002",
                CreatedDate = seedDateTime,
                Title = "Blue Performance Alloy Rim",
                Price = 88.99,
                SalePrice = 88.99,
                ProductArtUrl = "product_wheel_rim-blue.jpg",
                ProductDetails = "{ \"Material\" : \"Aluminum alloy\",  \"Design\" : \"Spoke\", \"Spokes\" : \"5\",  \"Number of Lugs\" : \"4\", \"Wheel Diameter\" : \"18 in.\", \"Color\" : \"Blue\", \"Finish\" : \"Glossy\" } ",
                Description = "Stand out from the crowd with a set of aftermarket blue rims to make you vehicle turn heads and at a price that will do the same.",
                LeadTime = 0,
                CreatedByUserId = SYSTEM_ADMIN_ID
            });
            products.Add(new Product
            {
                Id = 9,
                SkuNumber = "WHE-0003",
                CreatedDate = seedDateTime,
                Title = "High Performance Rim",
                Price = 99.99,
                SalePrice = 99.49,
                ProductArtUrl = "product_wheel_rim-red.jpg",
                ProductDetails = "{ \"Material\" : \"Aluminum alloy\",  \"Design\" : \"Spoke\", \"Spokes\" : \"12\",  \"Number of Lugs\" : \"5\", \"Wheel Diameter\" : \"18 in.\", \"Color\" : \"Red\", \"Finish\" : \"Matte\" } ",
                Description = "Light Weight Rims with a twin cross spoke design for stability and reliable performance.",
                LeadTime = 0,
                CreatedByUserId = SYSTEM_ADMIN_ID
            });
            products.Add(new Product
            {
                Id = 10,
                SkuNumber = "WHE-0004",
                CreatedDate = seedDateTime,
                Title = "Wheel Tire Combo",
                Price = 72.49,
                SalePrice = 72.49,
                ProductArtUrl = "product_wheel_tyre-wheel-combo.jpg",
                ProductDetails = "{ \"Material\" : \"Steel\",  \"Design\" : \"Spoke\", \"Spokes\" : \"8\",  \"Number of Lugs\" : \"4\", \"Wheel Diameter\" : \"19 in.\", \"Color\" : \"Gray\", \"Finish\" : \"Standard\", \"Pre-Assembled\" : \"Yes\" } ",
                Description = "For the endurance driver, take advantage of our best wearing tire yet. Composite rubber and a heavy duty steel rim.",
                LeadTime = 4,
                CreatedByUserId = SYSTEM_ADMIN_ID
            });
            products.Add(new Product
            {
                Id = 11,
                SkuNumber = "WHE-0005",
                CreatedDate = seedDateTime,
                Title = "Chrome Rim Tire Combo",
                Price = 129.99,
                SalePrice = 129.99,
                ProductArtUrl = "product_wheel_tyre-rim-chrome-combo.jpg",
                ProductDetails = "{ \"Material\" : \"Aluminum alloy\",  \"Design\" : \"Spoke\", \"Spokes\" : \"10\",  \"Number of Lugs\" : \"5\", \"Wheel Diameter\" : \"17 in.\", \"Color\" : \"Silver\", \"Finish\" : \"Chrome\", \"Pre-Assembled\" : \"Yes\" } ",
                Description = "Save time and money with our ever popular wheel and tire combo. Pre-assembled and ready to go.",
                LeadTime = 0,
                CreatedByUserId = SYSTEM_ADMIN_ID
            });
            products.Add(new Product
            {
                Id = 12,
                SkuNumber = "WHE-0006",
                CreatedDate = seedDateTime,
                Title = "Wheel Tire Combo (4 Pack)",
                Price = 219.99,
                SalePrice = 219.99,
                ProductArtUrl = "product_wheel_tyre-wheel-combo-pack.jpg",
                ProductDetails = "{ \"Material\" : \"Steel\",  \"Design\" : \"Spoke\", \"Spokes\" : \"8\",  \"Number of Lugs\" : \"5\", \"Wheel Diameter\" : \"19 in.\", \"Color\" : \"Gray\", \"Finish\" : \"Standard\", \"Pre-Assembled\" : \"Yes\" } ",
                Description = "Having trouble in the wet? Then try our special patent tire on a heavy duty steel rim. These wheels perform excellent in all conditions but were designed specifically for wet weather.",
                LeadTime = 0,
                CreatedByUserId = SYSTEM_ADMIN_ID
            });
            return products;
        }

        private List<Product> GetBatteries()
        {
            var products = new List<Product>();
            products.Add(new Product
            {
                Id = 13,
                SkuNumber = "BAT-0001",
                CreatedDate = seedDateTime,
                Title = "12-Volt Calcium Battery",
                Price = 129.99,
                SalePrice = 129.99,
                ProductArtUrl = "product_batteries_basic-battery.jpg",
                ProductDetails = "{ \"Type\": \"Calcium\", \"Volts\" : \"12\", \"Weight\" : \"22.9 lbs\", \"Size\" :  \"7.7x5x8.6\", \"Cold Cranking Amps\" : \"510\" }",
                Description = "Calcium is the most common battery type. It is durable and has a long shelf and service life. They also provide high cold cranking amps.",
                LeadTime = 0,
                CreatedByUserId = SYSTEM_ADMIN_ID
            });
            products.Add(new Product
            {
                Id = 14,
                SkuNumber = "BAT-0002",
                CreatedDate = seedDateTime,
                Title = "Spiral Coil Battery",
                Price = 154.99,
                SalePrice = 154.99,
                ProductArtUrl = "product_batteries_premium-battery.jpg",
                ProductDetails = "{ \"Type\": \"Spiral Coil\", \"Volts\" : \"12\", \"Weight\" : \"20.3 lbs\", \"Size\" :  \"7.4x5.1x8.5\", \"Cold Cranking Amps\" : \"460\" }",
                Description = "Spiral Coil batteries are the preferred option for high performance Vehicles where extra toque is need for starting. They are more resistant to heat and higher charge rates than conventional batteries.",
                LeadTime = 0,
                CreatedByUserId = SYSTEM_ADMIN_ID
            });
            products.Add(new Product
            {
                Id = 15,
                SkuNumber = "BAT-0003",
                CreatedDate = seedDateTime,
                Title = "Jumper Leads",
                Price = 16.99,
                SalePrice = 16.99,
                ProductArtUrl = "product_batteries_jumper-leads.jpg",
                ProductDetails = "{ \"length\" : \"6ft.\", \"Connection Type\" : \"Alligator Clips\", \"Fit\" : \"Universal\", \"Max Amp's\" : \"750\" }",
                Description = "Battery Jumper Leads have a built in surge protector and a includes a plastic carry case to keep them safe from corrosion.",
                LeadTime = 0,
                CreatedByUserId = SYSTEM_ADMIN_ID
            });
            return products;
        }

        private List<Product> GetOils()
        {
            var products = new List<Product>();
            products.Add(new Product
            {
                Id = 16,
                SkuNumber = "OIL-0001",
                CreatedDate = seedDateTime,
                Title = "Filter Set",
                Price = 28.99,
                SalePrice = 28.99,
                ProductArtUrl = "product_oil_filters.jpg",
                ProductDetails = "{ \"Filter Type\" : \"Canister and Cartridge\", \"Thread Size\" : \"0.75-16 in.\", \"Anti-Drainback Valve\" : \"Yes\"}",
                Description = "Ensure that your vehicle's engine has a longer life with our new filter set. Trapping more dirt to ensure old freely circulates through your engine.",
                LeadTime = 0,
                CreatedByUserId = SYSTEM_ADMIN_ID
            });
            products.Add(new Product
            {
                Id = 17,
                SkuNumber = "OIL-0002",
                CreatedDate = seedDateTime,
                Title = "Oil and Filter Combo",
                Price = 34.49,
                SalePrice = 34.49,
                ProductArtUrl = "product_oil_oil-filter-combo.jpg",
                ProductDetails = "{ \"Filter Type\" : \"Canister\", \"Thread Size\" : \"0.75-16 in.\", \"Anti-Drainback Valve\" : \"Yes\", \"Size\" : \"1.1 gal.\", \"Synthetic\" : \"No\" }",
                Description = "This Oil and Oil Filter combo is suitable for all types of passenger and light commercial vehicles. Providing affordable performance through excellent lubrication and breakdown resistance.",
                LeadTime = 0,
                CreatedByUserId = SYSTEM_ADMIN_ID
            });
            products.Add(new Product
            {
                Id = 18,
                SkuNumber = "OIL-0003",
                CreatedDate = seedDateTime,
                Title = "Synthetic Engine Oil",
                Price = 36.49,
                SalePrice = 36.49,
                ProductArtUrl = "product_oil_premium-oil.jpg",
                ProductDetails = "{ \"Size\" :  \"1.1 Gal.\" , \"Synthetic \" : \"Yes\"}",
                Description = "This Oil is designed to reduce sludge deposits and metal friction throughout your cars engine. Provides performance no matter the condition or temperature.",
                LeadTime = 0,
                CreatedByUserId = SYSTEM_ADMIN_ID
            });
            return products;
        }

        private void SeedStores(ModelBuilder modelBuilder)
        {
            var stores = new List<Store>()
            {
                new Store()
                {
                    Id = 1,
                    CreatedByUserId = SYSTEM_ADMIN_ID,
                    CreatedDate = seedDateTime,
                    IsActive = true,
                    Name = WEB_STORE
                },
                new Store()
                {
                    Id = 2,
                    CreatedByUserId = SYSTEM_ADMIN_ID,
                    CreatedDate = seedDateTime,
                    IsActive = true,
                    Name = STORE_1
                },
                new Store()
                {
                    Id = 3,
                    CreatedByUserId = SYSTEM_ADMIN_ID,
                    CreatedDate = seedDateTime,
                    IsActive = true,
                    Name = STORE_2
                }
            };

            modelBuilder.Entity<Store>().HasData(stores);
        }

        /*
         * WARNING: do not use this unless you have to, then create a separate migration without it enabled
         * If you leave this on, you will get new data on every run, and if you try to comment it out  you will delete your data on every new migration
         * so it is only here for emergency use if somehow you need new data and can't use the existing migration
         * 
        private void SeedStoreProducts(ModelBuilder modelBuilder)
        {
            //create a new list of products to associate
            var storeProducts = new List<StoreProduct>();

            storeProducts.AddRange(GenerateStoreBrakeProducts(1, 1));
            storeProducts.AddRange(GenerateStoreLightingProducts(1, 10));
            storeProducts.AddRange(GenerateStoreTireProducts(1, 20));
            storeProducts.AddRange(GenerateStoreBatteryProducts(1, 30));
            storeProducts.AddRange(GenerateStoreOilProducts(1, 40));

            storeProducts.AddRange(GenerateStoreBrakeProducts(2, 100));
            storeProducts.AddRange(GenerateStoreLightingProducts(2, 110));
            storeProducts.AddRange(GenerateStoreTireProducts(2, 120));
            storeProducts.AddRange(GenerateStoreBatteryProducts(2, 130));
            storeProducts.AddRange(GenerateStoreOilProducts(2, 140));

            storeProducts.AddRange(GenerateStoreBrakeProducts(2, 200));
            storeProducts.AddRange(GenerateStoreLightingProducts(2, 210));
            storeProducts.AddRange(GenerateStoreTireProducts(2, 220));
            storeProducts.AddRange(GenerateStoreBatteryProducts(2, 230));
            storeProducts.AddRange(GenerateStoreOilProducts(2, 240));

            modelBuilder.Entity<StoreProduct>().HasData(storeProducts);
        }

        private List<StoreProduct> GenerateStoreBrakeProducts(int storeId, int nextId)
        {
            Random r = new Random();
            var brakeProducts = GetBrakes();
            var storeProducts = new List<StoreProduct>();
            foreach (var b in brakeProducts)
            { 
                storeProducts.Add(new StoreProduct()
                {
                    CreatedByUserId = SYSTEM_ADMIN_ID,
                    CreatedDate = seedDateTime,
                    Id = nextId++,
                    IsActive = true,
                    OutOfStock = false,
                    QuantityOnHand = r.Next(2, 50),
                    QuantityOnOrder = r.Next(5, 10),
                    ProductId = b.Id,
                    StoreId = storeId
                }); 
            }

            return storeProducts;
        }

        private List<StoreProduct> GenerateStoreLightingProducts(int storeId, int nextId)
        {
            Random r = new Random();
            var products = GetLights();
            var storeProducts = new List<StoreProduct>();
            foreach (var p in products)
            {
                storeProducts.Add(new StoreProduct()
                {
                    CreatedByUserId = SYSTEM_ADMIN_ID,
                    CreatedDate = seedDateTime,
                    Id = nextId++,
                    IsActive = true,
                    OutOfStock = false,
                    QuantityOnHand = r.Next(2, 50),
                    QuantityOnOrder = r.Next(5, 10),
                    ProductId = p.Id,
                    StoreId = storeId
                });
            }

            return storeProducts;
        }

        private List<StoreProduct> GenerateStoreTireProducts(int storeId, int nextId)
        {
            Random r = new Random();
            var products = GetTires();
            var storeProducts = new List<StoreProduct>();
            foreach (var p in products)
            {
                storeProducts.Add(new StoreProduct()
                {
                    CreatedByUserId = SYSTEM_ADMIN_ID,
                    CreatedDate = seedDateTime,
                    Id = nextId++,
                    IsActive = true,
                    OutOfStock = false,
                    QuantityOnHand = r.Next(2, 50),
                    QuantityOnOrder = r.Next(5, 10),
                    ProductId = p.Id,
                    StoreId = storeId
                });
            }

            return storeProducts;
        }

        private List<StoreProduct> GenerateStoreBatteryProducts(int storeId, int nextId)
        {
            Random r = new Random();
            var products = GetBatteries();
            var storeProducts = new List<StoreProduct>();
            foreach (var p in products)
            {
                storeProducts.Add(new StoreProduct()
                {
                    CreatedByUserId = SYSTEM_ADMIN_ID,
                    CreatedDate = seedDateTime,
                    Id = nextId++,
                    IsActive = true,
                    OutOfStock = false,
                    QuantityOnHand = r.Next(2, 50),
                    QuantityOnOrder = r.Next(5, 10),
                    ProductId = p.Id,
                    StoreId = storeId
                });
            }

            return storeProducts;
        }

        private List<StoreProduct> GenerateStoreOilProducts(int storeId, int nextId)
        {
            Random r = new Random();
            var products = GetOils();
            var storeProducts = new List<StoreProduct>();
            foreach (var p in products)
            {
                storeProducts.Add(new StoreProduct()
                {
                    CreatedByUserId = SYSTEM_ADMIN_ID,
                    CreatedDate = seedDateTime,
                    Id = nextId++,
                    IsActive = true,
                    OutOfStock = false,
                    QuantityOnHand = r.Next(2, 50),
                    QuantityOnOrder = r.Next(5, 10),
                    ProductId = p.Id,
                    StoreId = storeId
                });
            }

            return storeProducts;
        }
        */
    }
}
