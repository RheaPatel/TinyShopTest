using System;
using System.Collections.Generic;
using System.Linq;
using TinyShop.Web.Models;

namespace TinyShop.Web.Services
{
    public class CartService
    {
        private List<CartItem> _cartItems = new List<CartItem>();

        public IEnumerable<CartItem> CartItems => _cartItems;

        public int TotalItems => _cartItems.Sum(item => item.Quantity);

        public decimal TotalPrice => _cartItems.Sum(item => item.Product.Price * item.Quantity);

        public void AddToCart(Product product)
        {
            var existingItem = _cartItems.FirstOrDefault(item => item.Product.Id == product.Id);
            
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                _cartItems.Add(new CartItem { Product = product, Quantity = 1 });
            }
        }

        public void RemoveFromCart(int productId)
        {
            var item = _cartItems.FirstOrDefault(item => item.Product.Id == productId);
            
            if (item != null)
            {
                if (item.Quantity > 1)
                {
                    item.Quantity--;
                }
                else
                {
                    _cartItems.Remove(item);
                }
            }
        }

        public void ClearCart()
        {
            _cartItems.Clear();
        }
    }
}