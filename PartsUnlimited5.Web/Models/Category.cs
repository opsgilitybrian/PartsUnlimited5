using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsUnlimited5.Web.Models
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [StringLength(2048)]
        public string Description { get; set; }

        [StringLength(2048)]
        public string ImageUrl { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
