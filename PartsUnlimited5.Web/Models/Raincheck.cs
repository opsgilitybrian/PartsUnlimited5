using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace PartsUnlimited5.Web.Models
{
    public class Raincheck : BaseEntity
    {
        [Display(Name = "Customer Email")]
        public virtual string UserId { get; set; }
        public virtual IdentityUser User { get; set; }

        [Required]
        public int IssuerStoreId { get; set; }

        public virtual Store IssuerStore { get; set; }
    }
}
