using System;
using System.Collections.Generic;

namespace Shops.Services
{
    public class ShopManager
    {
        public ShopManager(Shop newShop)
        {
            Shop = newShop;
        }

        public Shop Shop { get; }
        private List<Product> _products = new List<Product>();

        public void AddProducts(List<Product> newProducts)
        {
            foreach (Product newProduct in newProducts)
            {
                Product oldProduct = _products.Find(p => p.Name == newProduct.Name) ?? throw new Exception();
                if (oldProduct == newProduct)
                {
                    _products.Remove(oldProduct);
                    _products.Add(new Product(oldProduct.Name, oldProduct.Number + newProduct.Number, oldProduct.Price));
                }
                else
                {
                    _products.Add(newProduct);
                }
            }

            _products.AddRange(newProducts);
        }

        public int BuyProducts(List<ProductSample> sellProducts)
        {
            int price = 0;
            foreach (ProductSample sellProduct in sellProducts)
            {
                Product oldProduct = _products.Find(p => p.Name == sellProduct.Name) ?? throw new Exception();
                if (oldProduct.Number - sellProduct.Number < 0) throw new Exception("not enough products");
                var changedProduct = new Product(sellProduct.Name, oldProduct.Number - sellProduct.Number, oldProduct.Price);
                _products.Remove(oldProduct);
                _products.Add(changedProduct);
                price = (oldProduct.Price * sellProduct.Number) + price;
            }

            return price;
        }

        public void ChangePrice(string productName, int newPrice)
        {
            Product product = _products.Find(p => p.Name == productName) ?? throw new Exception("Product not find");
            _products.Remove(product);
            _products.Add(new Product(product.Name, product.Number, newPrice));
        }

        public Product FindProduct(ProductSample product)
        {
            Product foundProduct = _products.Find(p => p.Name == product.Name);
            return foundProduct;
        }
    }
}