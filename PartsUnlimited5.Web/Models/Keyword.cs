using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsUnlimited5.Web.Models
{
    public class Keyword : BaseEntity
    {
        [Required]
        [StringLength(2048)]
        public string Word { get; set; }
    }
}
