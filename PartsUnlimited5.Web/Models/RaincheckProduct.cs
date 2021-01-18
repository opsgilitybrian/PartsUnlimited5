using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsUnlimited5.Web.Models
{
    public class RaincheckProduct : BaseEntity
    {
        public virtual int RaincheckId { get; set; }
        public virtual Raincheck Raincheck { get; set; }

        public virtual int StoreProductId { get; set; }
        public virtual StoreProduct StoreProduct { get; set; }

        [Required]
        [Range(1, 100)]
        public int Count { get; set; }

        [Required]
        [Range(0.01, 99999.99)]
        public double SalePrice { get; set; }
    }
}
