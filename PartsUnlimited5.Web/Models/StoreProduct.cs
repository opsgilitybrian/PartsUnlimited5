using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsUnlimited5.Web.Models
{
    public class StoreProduct : BaseEntity
    {
        public virtual int StoreId { get; set; }
        public virtual Store Store { get; set; }
        public virtual int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int QuantityOnHand { get; set; }
        public int QuantityOnOrder { get; set; }

        public bool OutOfStock { get; set; }
        public DateTime ExpectedInStockDate { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual List<ShoppingCartItem> AllCartItems { get; set; }

        public virtual List<RaincheckProduct> AllRaincheckProducts { get; set; }
    }
}
