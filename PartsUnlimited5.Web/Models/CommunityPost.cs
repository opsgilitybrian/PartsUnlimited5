using PartsUnlimited5.Web.Models.Enumerations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PartsUnlimited5.Web.Models
{
    public class CommunityPost : BaseEntity
    {
        [StringLength(2048)]
        public string ImageURL { get; set; }
        public string DatePosted { get; set; }
        public CommunitySource Source { get; set; }
    }
}
