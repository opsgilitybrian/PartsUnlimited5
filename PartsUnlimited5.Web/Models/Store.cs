using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PartsUnlimited5.Web.Models
{
    public class Store : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public virtual List<StoreProduct> Inventory { get; set; }

        public virtual List<Raincheck> StoreRainchecks { get; set; }
    }
}
