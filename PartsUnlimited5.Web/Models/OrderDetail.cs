using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsUnlimited5.Web.Models
{
    public class OrderDetail : BaseEntity
    {
        [Required]
        [Range(1, 100)]
        public int Count { get; set; }

        [Required]
        [Range(0.01, 99999.99)]
        public double UnitPrice { get; set; }
        
        [Required]
        public virtual int OrderId { get; set; }
        public virtual Order Order { get; set; }

        [Required]
        public virtual int StoreProductId { get; set; }
        public virtual StoreProduct StoreProduct { get; set; }

        public double OrderDetailTotal => Count * UnitPrice;
    }
}
