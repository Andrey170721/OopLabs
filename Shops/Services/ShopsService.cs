using System;
using System.Collections.Generic;
using Shops.Tools;

namespace Shops.Services
{
    public class ShopsService : IShopsService
    {
        private List<Shop> _shops = new List<Shop>();
        private List<ProductManager> _shopManagers = new List<ProductManager>();
        private int _id = 0;
        public Shop AddShop(string name, string address)
        {
            var shop = new Shop(_id, name, address);
            _shops.Add(shop);
            _shopManagers.Add(new ProductManager(shop));
            _id++;
            return shop;
        }

        public Client AddClient(string name, int amountMoney)
        {
            var client = new Client(name, amountMoney);
            return client;
        }

        public void AddProducts(Shop shop, List<Product> products)
        {
            ProductManager manager = _shopManagers.Find(m => m.Shop == shop) ?? throw new ShopException("manager not found");
            manager.AddProducts(products);
        }

        public void BuyProducts(Client client, Shop shop, List<ProductSample> shopList)
        {
            ProductManager manager = _shopManagers.Find(m => m.Shop == shop) ?? throw new ShopException("manager not found");
            int price = manager.BuyProducts(shopList);
            Client changedClient = client.Buy(price);
        }

        public void SetPrice(Shop shop, string productName, int newPrice)
        {
            ProductManager manager = _shopManagers.Find(m => m.Shop == shop) ?? throw new ShopException("manager not found");
            manager.ChangePrice(productName, newPrice);
        }

        public Shop FindMinPrice(ProductSample product)
        {
            Shop minPriceShop = null;
            int minPrice = int.MaxValue;
            foreach (Shop shop in _shops)
            {
                ProductManager manager = _shopManagers.Find(m => m.Shop == shop) ?? throw new Exception("manager not found");
                Product foundProduct = manager.FindProduct(product);
                if (foundProduct != null)
                {
                    if (minPrice > foundProduct.Price && foundProduct.Number > product.Number)
                    {
                        minPrice = foundProduct.Price;
                        minPriceShop = shop;
                    }
                }
            }

            return minPriceShop ?? throw new ShopException("Product not found");
        }

        public List<Product> GetProductList(Shop shop)
        {
            ProductManager manager = _shopManagers.Find(m => m.Shop == shop) ?? throw new ShopException("manager not found");
            return manager.GetProductList();
        }
    }
}