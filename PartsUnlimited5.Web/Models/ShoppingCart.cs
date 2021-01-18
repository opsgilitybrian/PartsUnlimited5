using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PartsUnlimited5.Web.Models
{
    public class ShoppingCart : BaseEntity
    {
        [Display(Name = "User Email")]
        public virtual string UserId { get; set; }
        public virtual IdentityUser User { get; set; }

        private List<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();

        public void AddItem(StoreProduct p, int count, double price)
        {
            //todo: get the current cart for this user.

            var exists = ShoppingCartItems.FirstOrDefault(x => x.StoreProduct.Id == p.Id);
            if (exists != null)
            {
                exists.Count += count;
            }
            else
            {
                ShoppingCartItems.Add(new ShoppingCartItem()
                {
                    IsActive = true,
                    Count = count,
                    StoreProductId = p.Id,
                    StoreProduct = p,
                    ShoppingCartId = Id,
                    ShoppingCart = this,
                    UnitPrice = price,
                });
            }

            //todo finish this someday
        }

        public void RemoveItem(Product p, int count)
        { 
            //todo work this out
        }

        public double ShoppingCartTotal => ShoppingCartItems.Sum(item => item.ItemTotal);
    }
}
