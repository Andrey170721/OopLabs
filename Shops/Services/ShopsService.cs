using System;
using System.Collections.Generic;

namespace Shops.Services
{
    public class ShopsService : IShopsService
    {
        private List<Shop> _shops = new List<Shop>();
        private List<ShopManager> _shopManagers = new List<ShopManager>();
        private int _id = 0;
        public Shop AddShop(string name, string address)
        {
            var shop = new Shop(_id, name, address);
            _shops.Add(shop);
            _shopManagers.Add(new ShopManager(shop));
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
            ShopManager manager = _shopManagers.Find(m => m.Shop == shop) ?? throw new Exception();
            manager.AddProducts(products);
        }

        public void BuyProducts(Client client, Shop shop, List<ProductSample> shopList)
        {
            ShopManager manager = _shopManagers.Find(m => m.Shop == shop) ?? throw new Exception();
            int price = manager.BuyProducts(shopList);
            Client changedClient = client.Buy(price);
        }

        public void SetPrice(Shop shop, string productName, int newPrice)
        {
            ShopManager manager = _shopManagers.Find(m => m.Shop == shop) ?? throw new Exception();
            manager.ChangePrice(productName, newPrice);
        }

        public Shop FindMinPrice(ProductSample product)
        {
            Shop minPriceShop = null;
            int minPrice = int.MaxValue;
            foreach (Shop shop in _shops)
            {
                ShopManager manager = _shopManagers.Find(m => m.Shop == shop) ?? throw new Exception();
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

            return minPriceShop ?? throw new Exception("Product not found");
        }

        public List<Product> GetProductList(Shop shop)
        {
            ShopManager manager = _shopManagers.Find(m => m.Shop == shop) ?? throw new Exception();
            return manager.GetProductList();
        }
    }
}