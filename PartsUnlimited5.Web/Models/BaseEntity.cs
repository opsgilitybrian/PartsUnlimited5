using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PartsUnlimited5.Web.Models
{
    public abstract class BaseEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public string CreatedByUserId { get; set; }
        public virtual IdentityUser CreatedByUser { get; set; }

        public DateTime? LastModifiedDate { get; set; }
        public string LastModifiedByUserId { get; set; }
        public virtual IdentityUser LastModifiedByUser { get; set; }

    }
}
