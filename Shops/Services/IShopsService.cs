using System;
using System.Collections.Generic;

namespace Shops.Services
{
    public interface IShopsService
    {
        Shop AddShop(string name, string address);

        Client AddClient(string name, int amountMoney);

        void AddProducts(Shop shop, List<Product> products);

        void BuyProducts(Client client, Shop shop, List<ProductSample> shopList);

        void SetPrice(Shop shop, string productName, int newPrice);

        Shop FindMinPrice(ProductSample product);
        public List<Product> GetProductList(Shop shop);
    }
}