using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsUnlimited5.Web.Models
{
    public class Manufacturer : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        //TODO: Enhance to have a contact in phase 2
    }
}
