using System;
using System.Collections.Generic;
using Shops.Services;
using NUnit.Framework;


namespace Shops.Tests
{
    public class Tests
    {
        private IShopsService _shopsService;

        [SetUp]
        public void Setup()
        {
            _shopsService = new ShopsService();
        }

        [Test]
        public void AddProductsToShop()
        {
            var shop = _shopsService.AddShop("sevenEleven", "street1");
            var productList = new List<Product>();
            productList.Add(new Product("Apple", 3, 25));
            _shopsService.AddProducts(shop, productList);
            List<Product> prList = _shopsService.GetProductList(shop);
            Assert.AreEqual(prList, productList);

        }

        [Test]
        public void SetProductPrice()
        {
            var shop = _shopsService.AddShop("sevenEleven", "street1");
            var productList = new List<Product>();
            productList.Add(new Product("Apple", 3, 25));
            _shopsService.AddProducts(shop, productList);
            _shopsService.SetPrice(shop, "Apple", 40);
            List<Product> prList = _shopsService.GetProductList(shop);
            productList = new List<Product>();
            productList.Add(new Product("Apple", 3, 40));
        }

        [Test]
        public void FindMinPrice()
        {
            var shop1 = _shopsService.AddShop("sevenEleven", "street1");
            var productList1 = new List<Product>();
            productList1.Add(new Product("Apple", 3, 25));
            _shopsService.AddProducts(shop1, productList1);
            var shop2 = _shopsService.AddShop("Fresh", "street2");
            var productList2 = new List<Product>();
            productList2.Add(new Product("Apple", 3, 30));
            _shopsService.AddProducts(shop2, productList2);
            ProductSample product1 = new ProductSample("Apple", 3);
        }

        [Test]
        public void BuyProducts()
        {
            var shop = _shopsService.AddShop("sevenEleven", "street1");
            var productList = new List<Product>();
            productList.Add(new Product("Apple", 3, 25));
            _shopsService.AddProducts(shop, productList);
            Client client = _shopsService.AddClient("Ivan", 300);
            ProductSample product1 = new ProductSample("Apple", 3);
            List<ProductSample> list = new List<ProductSample>();
            list.Add(product1);
            _shopsService.BuyProducts(client, shop, list);
        }
    }
}