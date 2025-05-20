using System;
using System.Collections.Generic;
using System.Linq;
using TinyShop.DataEntities;

namespace TinyShop.Store.Services
{
    public class CartService
    {
        private readonly List<CartItem> _cartItems = new();

        // Event that will be triggered when cart changes
        public event Action? OnCartChanged;

        public IReadOnlyList<CartItem> CartItems => _cartItems.AsReadOnly();

        public int TotalItems => _cartItems.Sum(item => item.Quantity);

        public decimal TotalPrice => _cartItems.Sum(item => item.Quantity * item.Product.Price);

        // Method to notify cart changes
        private void NotifyCartChanged() => OnCartChanged?.Invoke();

        public void AddToCart(Product product, int quantity = 1)
        {
            var existingItem = _cartItems.FirstOrDefault(item => item.Product.Id == product.Id);
            
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _cartItems.Add(new CartItem { Product = product, Quantity = quantity });
            }
            
            NotifyCartChanged();
        }

        public void RemoveFromCart(int productId)
        {
            var item = _cartItems.FirstOrDefault(item => item.Product.Id == productId);
            
            if (item != null)
            {
                _cartItems.Remove(item);
                NotifyCartChanged();
            }
        }

        public void UpdateQuantity(int productId, int quantity)
        {
            var item = _cartItems.FirstOrDefault(item => item.Product.Id == productId);
            
            if (item != null)
            {
                if (quantity <= 0)
                {
                    RemoveFromCart(productId);
                }
                else
                {
                    item.Quantity = quantity;
                    NotifyCartChanged();
                }
            }
        }

        public void ClearCart()
        {
            _cartItems.Clear();
            NotifyCartChanged();
        }
    }

    public class CartItem
    {
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }
    }
}