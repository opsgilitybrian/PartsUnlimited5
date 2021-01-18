using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace PartsUnlimited5.Web.Models
{
    public class Product : BaseEntity
    {
        [Required]
        [Display(Name = "Sku Number")]
        public string SkuNumber { get; set; }

        [Required]
        [StringLength(160, MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [Range(0.01, 99999.99)]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Range(0.01, 99999.99)]
        [DataType(DataType.Currency)]
        public double SalePrice { get; set; }

        [Display(Name = "Product Art URL")]
        [StringLength(2048)]
        public string ProductArtUrl { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual List<Category> Categories { get; set; }


        [Required]
        [Display(Name = "Product Details")]
        [StringLength(2048)]
        public string ProductDetails { get; set; }

        public int LeadTime { get; set; }

        //not sure what this is for?
        //public Dictionary<string, string> ProductDetailList
        //{
        //    get
        //    {
        //        if (string.IsNullOrWhiteSpace(ProductDetails))
        //        {
        //            return new Dictionary<string, string>();
        //        }
        //        return JsonSerializer.Deserialize<Dictionary<string, string>>(ProductDetails);
        //    }
        //}

        public virtual List<Keyword> ProductKeywords { get; set; }

        public virtual int? ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        public virtual List<StoreProduct> AllInventory { get; set; }
    }
}
