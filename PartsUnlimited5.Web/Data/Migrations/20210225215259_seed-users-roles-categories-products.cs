using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PartsUnlimited5.Web.Data.Migrations
{
    public partial class seedusersrolescategoriesproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e60bc581-bc55-41ca-9ae6-ace692e15ae5", "1", "SystemAdmin", "SYSTEMADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "39ff8dfb-95d0-4ab5-b32b-3b85d26508c0", "2", "GeneralCustomer", "GENERALCUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e1367305-f547-43e0-9af3-3e5e0861844b", 0, "81570d0b-c116-41f3-91e0-298c3a027d06", "seedadministrator@example.com", true, false, null, "SEEDADMINISTRATOR@EXAMPLE.COM", "SEEDADMINISTRATOR", "AQAAAAEAACcQAAAAEB9FIk0z5Ci79JEGK06lndZgQ9Ago2FxFkN4MlVZQD1Di+6zFcuEu/KiINwnmVrspw==", null, false, "4d80d994-9453-44f8-9c46-e49d627f46a4", false, "SeedAdministrator" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e60bc581-bc55-41ca-9ae6-ace692e15ae5", "e1367305-f547-43e0-9af3-3e5e0861844b" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedByUserId", "CreatedDate", "Description", "ImageUrl", "IsActive", "LastModifiedByUserId", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "e1367305-f547-43e0-9af3-3e5e0861844b", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brakes for your buggy", null, true, null, null, "Brakes" },
                    { 2, "e1367305-f547-43e0-9af3-3e5e0861844b", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lighting for your buggy", null, true, null, null, "Lighting" },
                    { 3, "e1367305-f547-43e0-9af3-3e5e0861844b", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wheels and Tires for your buggy", null, true, null, null, "WheelsAndTires" },
                    { 4, "e1367305-f547-43e0-9af3-3e5e0861844b", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Batteries for your buggy", null, true, null, null, "Batteries" },
                    { 5, "e1367305-f547-43e0-9af3-3e5e0861844b", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oil for your buggy", null, true, null, null, "Oil" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedByUserId", "CreatedDate", "Description", "IsActive", "LastModifiedByUserId", "LastModifiedDate", "LeadTime", "ManufacturerId", "Price", "ProductArtUrl", "ProductDetails", "SalePrice", "SkuNumber", "Title" },
                values: new object[,]
                {
                    { 16, "e1367305-f547-43e0-9af3-3e5e0861844b", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ensure that your vehicle's engine has a longer life with our new filter set. Trapping more dirt to ensure old freely circulates through your engine.", false, null, null, 0, null, 28.989999999999998, "product_oil_filters.jpg", "{ \"Filter Type\" : \"Canister and Cartridge\", \"Thread Size\" : \"0.75-16 in.\", \"Anti-Drainback Valve\" : \"Yes\"}", 28.989999999999998, "OIL-0001", "Filter Set" },
                    { 15, "e1367305-f547-43e0-9af3-3e5e0861844b", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Battery Jumper Leads have a built in surge protector and a includes a plastic carry case to keep them safe from corrosion.", false, null, null, 0, null, 16.989999999999998, "product_batteries_jumper-leads.jpg", "{ \"length\" : \"6ft.\", \"Connection Type\" : \"Alligator Clips\", \"Fit\" : \"Universal\", \"Max Amp's\" : \"750\" }", 16.989999999999998, "BAT-0003", "Jumper Leads" },
                    { 14, "e1367305-f547-43e0-9af3-3e5e0861844b", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spiral Coil batteries are the preferred option for high performance Vehicles where extra toque is need for starting. They are more resistant to heat and higher charge rates than conventional batteries.", false, null, null, 0, null, 154.99000000000001, "product_batteries_premium-battery.jpg", "{ \"Type\": \"Spiral Coil\", \"Volts\" : \"12\", \"Weight\" : \"20.3 lbs\", \"Size\" :  \"7.4x5.1x8.5\", \"Cold Cranking Amps\" : \"460\" }", 154.99000000000001, "BAT-0002", "Spiral Coil Battery" },
                    { 13, "e1367305-f547-43e0-9af3-3e5e0861844b", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Calcium is the most common battery type. It is durable and has a long shelf and service life. They also provide high cold cranking amps.", false, null, null, 0, null, 129.99000000000001, "product_batteries_basic-battery.jpg", "{ \"Type\": \"Calcium\", \"Volts\" : \"12\", \"Weight\" : \"22.9 lbs\", \"Size\" :  \"7.7x5x8.6\", \"Cold Cranking Amps\" : \"510\" }", 129.99000000000001, "BAT-0001", "12-Volt Calcium Battery" },
                    { 12, "e1367305-f547-43e0-9af3-3e5e0861844b", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Having trouble in the wet? Then try our special patent tire on a heavy duty steel rim. These wheels perform excellent in all conditions but were designed specifically for wet weather.", false, null, null, 0, null, 219.99000000000001, "product_wheel_tyre-wheel-combo-pack.jpg", "{ \"Material\" : \"Steel\",  \"Design\" : \"Spoke\", \"Spokes\" : \"8\",  \"Number of Lugs\" : \"5\", \"Wheel Diameter\" : \"19 in.\", \"Color\" : \"Gray\", \"Finish\" : \"Standard\", \"Pre-Assembled\" : \"Yes\" } ", 219.99000000000001, "WHE-0006", "Wheel Tire Combo (4 Pack)" },
                    { 11, "e1367305-f547-43e0-9af3-3e5e0861844b", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Save time and money with our ever popular wheel and tire combo. Pre-assembled and ready to go.", false, null, null, 0, null, 129.99000000000001, "product_wheel_tyre-rim-chrome-combo.jpg", "{ \"Material\" : \"Aluminum alloy\",  \"Design\" : \"Spoke\", \"Spokes\" : \"10\",  \"Number of Lugs\" : \"5\", \"Wheel Diameter\" : \"17 in.\", \"Color\" : \"Silver\", \"Finish\" : \"Chrome\", \"Pre-Assembled\" : \"Yes\" } ", 129.99000000000001, "WHE-0005", "Chrome Rim Tire Combo" },
                    { 10, "e1367305-f547-43e0-9af3-3e5e0861844b", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "For the endurance driver, take advantage of our best wearing tire yet. Composite rubber and a heavy duty steel rim.", false, null, null, 4, null, 72.489999999999995, "product_wheel_tyre-wheel-combo.jpg", "{ \"Material\" : \"Steel\",  \"Design\" : \"Spoke\", \"Spokes\" : \"8\",  \"Number of Lugs\" : \"4\", \"Wheel Diameter\" : \"19 in.\", \"Color\" : \"Gray\", \"Finish\" : \"Standard\", \"Pre-Assembled\" : \"Yes\" } ", 72.489999999999995, "WHE-0004", "Wheel Tire Combo" },
                    { 9, "e1367305-f547-43e0-9af3-3e5e0861844b", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Light Weight Rims with a twin cross spoke design for stability and reliable performance.", false, null, null, 0, null, 99.989999999999995, "product_wheel_rim-red.jpg", "{ \"Material\" : \"Aluminum alloy\",  \"Design\" : \"Spoke\", \"Spokes\" : \"12\",  \"Number of Lugs\" : \"5\", \"Wheel Diameter\" : \"18 in.\", \"Color\" : \"Red\", \"Finish\" : \"Matte\" } ", 99.489999999999995, "WHE-0003", "High Performance Rim" },
                    { 6, "e1367305-f547-43e0-9af3-3e5e0861844b", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), " Clear bulb that with a universal fitting for all headlights/taillights.  Simple Installation, low wattage and a clear light for optimal visibility and efficiency.", false, null, null, 0, null, 6.4900000000000002, "product_lighting_lightbulb.jpg", "{ \"Color\" : \"Clear\", \"Fit\" : \"Universal\", \"Wattage\" : \"30 Watts\", \"Includes Socket\" : \"Yes\"}", 6.4900000000000002, "LIG-0003", "Turn Signal Light Bulb" },
                    { 7, "e1367305-f547-43e0-9af3-3e5e0861844b", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Parts Unlimited favorite, the Matte Finish Rim is affordable low profile style. Fits all low profile tires.", false, null, null, 0, null, 75.989999999999995, "product_wheel_rim.jpg", "{ \"Material\" : \"Aluminum alloy\",  \"Design\" : \"Spoke\", \"Spokes\" : \"9\",  \"Number of Lugs\" : \"4\", \"Wheel Diameter\" : \"17 in.\", \"Color\" : \"Black\", \"Finish\" : \"Matte\" } ", 75.989999999999995, "WHE-0001", "Matte Finish Rim" },
                    { 17, "e1367305-f547-43e0-9af3-3e5e0861844b", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This Oil and Oil Filter combo is suitable for all types of passenger and light commercial vehicles. Providing affordable performance through excellent lubrication and breakdown resistance.", false, null, null, 0, null, 34.490000000000002, "product_oil_oil-filter-combo.jpg", "{ \"Filter Type\" : \"Canister\", \"Thread Size\" : \"0.75-16 in.\", \"Anti-Drainback Valve\" : \"Yes\", \"Size\" : \"1.1 gal.\", \"Synthetic\" : \"No\" }", 34.490000000000002, "OIL-0002", "Oil and Filter Combo" },
                    { 5, "e1367305-f547-43e0-9af3-3e5e0861844b", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Our Bugeye Headlights use Halogen light bulbs are made to fit into a standard Bugeye slot. Product requires some assembly and includes light bulbs.", false, null, null, 0, null, 48.990000000000002, "product_lighting_bugeye-headlight.jpg", "{ \"Light Source\" : \"Halogen\", \"Assembly Required\": \"Yes\", \"Color\" : \"Clear\", \"Interior\" : \"Chrome\", \"Beam\": \"low and high\", \"Wiring harness included\" : \"No\", \"Bulbs Included\" : \"Yes\",  \"Includes Parking Signal\" : \"Yes\"}", 48.990000000000002, "LIG-0002", "Bugeye Headlights (2 Pack)" },
                    { 4, "e1367305-f547-43e0-9af3-3e5e0861844b", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Our Halogen Headlights are made to fit majority of vehicles with our  universal fitting mold. Product requires some assembly and includes light bulbs.", false, null, null, 0, null, 38.990000000000002, "product_lighting_headlight.jpg", "{ \"Light Source\" : \"Halogen\", \"Assembly Required\": \"Yes\", \"Color\" : \"Clear\", \"Interior\" : \"Chrome\", \"Beam\": \"low and high\", \"Wiring harness included\" : \"Yes\", \"Bulbs Included\" : \"No\",  \"Includes Parking Signal\" : \"Yes\"}", 38.990000000000002, "LIG-0001", "Halogen Headlights (2 Pack)" },
                    { 3, "e1367305-f547-43e0-9af3-3e5e0861844b", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Upgrading your brakes can increase stopping power, reduce dust and noise. Our Disk Calipers exceed factory specification for the best performance.", false, null, null, 0, null, 43.990000000000002, "product_brakes_disc-calipers-red.jpg", "{\"Disk Design\" : \"Cross Drill Slotted\", \" Pad Material\" : \"Carbon Ceramic\",  \"Construction\" : \"Vented Rotor\", \"Diameter\" : \"11.3 in.\", \"Bolt Pattern\": \"6 x 5.31 in.\", \"Finish\" : \"Silver Zinc Plated\",  \"Material\" : \"Carbon Alloy\", \"Includes Brake Pads\" : \"Yes\" }", 43.990000000000002, "BRA-0003", "Brake Disk and Calipers" },
                    { 2, "e1367305-f547-43e0-9af3-3e5e0861844b", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Our Brake Rotor Performs well in wet conditions with a smooth responsive feel. Machined to a high tolerance to ensure all of our Brake Rotors are safe and reliable.", false, null, null, 0, null, 18.989999999999998, "product_brakes_disc.jpg", "{ \"Disk Design\" : \"Cross Drill Slotted\",  \"Construction\" : \"Vented Rotor\", \"Diameter\" : \"10.3 in.\", \"Finish\" : \"Silver Zinc Plated\", \"Hat Finish\" : \"Black E-coating\",  \"Material\" : \"Cast Iron\" }", 18.989999999999998, "BRA-0002", "Brake Rotor" },
                    { 1, "e1367305-f547-43e0-9af3-3e5e0861844b", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Our brake disks and pads perform the best together. Better stopping distances without locking up, reduced rust and dusk.", false, null, null, 6, null, 25.989999999999998, "product_brakes_disk-pad-combo.jpg", "{ \"Disk Design\" : \"Cross Drill Slotted\", \" Pad Material\" : \"Ceramic\", \"Construction\" : \"Vented Rotor\", \"Diameter\" : \"10.3 in.\", \"Finish\" : \"Silver Zinc Plated\", \"Hat Finish\" : \"Silver Zinc Plated\", \"Material\" : \"Cast Iron\" }", 25.989999999999998, "BRA-0001", "Disk and Pad Combo" },
                    { 8, "e1367305-f547-43e0-9af3-3e5e0861844b", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stand out from the crowd with a set of aftermarket blue rims to make you vehicle turn heads and at a price that will do the same.", false, null, null, 0, null, 88.989999999999995, "product_wheel_rim-blue.jpg", "{ \"Material\" : \"Aluminum alloy\",  \"Design\" : \"Spoke\", \"Spokes\" : \"5\",  \"Number of Lugs\" : \"4\", \"Wheel Diameter\" : \"18 in.\", \"Color\" : \"Blue\", \"Finish\" : \"Glossy\" } ", 88.989999999999995, "WHE-0002", "Blue Performance Alloy Rim" },
                    { 18, "e1367305-f547-43e0-9af3-3e5e0861844b", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This Oil is designed to reduce sludge deposits and metal friction throughout your cars engine. Provides performance no matter the condition or temperature.", false, null, null, 0, null, 36.490000000000002, "product_oil_premium-oil.jpg", "{ \"Size\" :  \"1.1 Gal.\" , \"Synthetic \" : \"Yes\"}", 36.490000000000002, "OIL-0003", "Synthetic Engine Oil" }
                });

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoriesId", "ProductsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 3, 7 },
                    { 3, 8 },
                    { 3, 9 },
                    { 3, 10 },
                    { 3, 11 },
                    { 3, 12 },
                    { 4, 13 },
                    { 4, 14 },
                    { 4, 15 },
                    { 5, 16 },
                    { 5, 17 },
                    { 5, 18 }
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39ff8dfb-95d0-4ab5-b32b-3b85d26508c0");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e60bc581-bc55-41ca-9ae6-ace692e15ae5", "e1367305-f547-43e0-9af3-3e5e0861844b" });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

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

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e60bc581-bc55-41ca-9ae6-ace692e15ae5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1367305-f547-43e0-9af3-3e5e0861844b");
        }
    }
}
