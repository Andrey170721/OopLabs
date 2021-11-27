using System;
using System.Collections.Generic;
using Shops.Tools;

namespace Shops.Services
{
    public class ProductManager
    {
        private List<Product> _products = new List<Product>();
        public ProductManager(Shop newShop)
        {
            Shop = newShop;
        }

        public Shop Shop { get; }
        public void AddProducts(List<Product> newProducts)
        {
            foreach (Product newProduct in newProducts)
            {
                Product oldProduct = _products.Find(p => p.Name == newProduct.Name);
                if (oldProduct != null)
                {
                    _products.Remove(oldProduct);
                    _products.Add(new Product(oldProduct.Name, oldProduct.Number + newProduct.Number, oldProduct.Price));
                }
                else
                {
                    _products.Add(newProduct);
                }
            }
        }

        public int BuyProducts(List<ProductSample> sellProducts)
        {
            int price = 0;
            foreach (ProductSample sellProduct in sellProducts)
            {
                Product oldProduct = _products.Find(p => p.Name == sellProduct.Name) ?? throw new ShopException();
                if (oldProduct.Number - sellProduct.Number < 0) throw new ShopException("not enough products");
                var changedProduct = new Product(sellProduct.Name, oldProduct.Number - sellProduct.Number, oldProduct.Price);
                _products.Remove(oldProduct);
                _products.Add(changedProduct);
                price = (oldProduct.Price * sellProduct.Number) + price;
            }

            return price;
        }

        public void ChangePrice(string productName, int newPrice)
        {
            Product product = _products.Find(p => p.Name == productName) ?? throw new ShopException("Product not find");
            _products.Remove(product);
            _products.Add(new Product(product.Name, product.Number, newPrice));
        }

        public Product FindProduct(ProductSample product)
        {
            Product foundProduct = _products.Find(p => p.Name == product.Name);
            return foundProduct;
        }

        public List<Product> GetProductList()
        {
            return _products;
        }
    }
}