using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsUnlimited5.Web.Models
{
    public class Order : BaseEntity
    {
        [Required]
        public DateTime OrderDate { get; set; }

        public virtual int ShippingAddressId { get; set; }
        public virtual Address ShippingAddress { get; set; }

        //todo: enhance with billing address different from shipping address

        [Required]
        public double Total { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
