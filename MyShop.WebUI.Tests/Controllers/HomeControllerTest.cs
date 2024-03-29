﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyShop.WebUI;
using MyShop.WebUI.Controllers;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using MyShop.Core.Contracts;

namespace MyShop.WebUI.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IndexPageDoesReturnProduct()
        {
            IRepository<Product> productContext = new Mocks.MockContext<Product>();
            IRepository<Service> serviceContext = new Mocks.MockContext<Service>();
            IRepository<Shop> shopContext = new Mocks.MockContext<Shop>();
            IRepository<ProductCategory> productCategoryContext = new Mocks.MockContext<ProductCategory>();
            HomeController controller = new HomeController(productContext, serviceContext, shopContext, productCategoryContext);

            productContext.Insert(new Product());

            var result = controller.Index(serviceLocation: "") as ViewResult;
            var viewModel = (ProductViewListViewModel)result.ViewData.Model;

            Assert.AreEqual(1, viewModel.Products.Count());



        }


    }
}
