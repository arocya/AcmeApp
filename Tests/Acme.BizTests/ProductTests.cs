﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void SayHelloTest()
        {
            // Arrange 
            var currentProduct = new Product();
            currentProduct.ProductName = "Saw";
            currentProduct.ProductId = 1;
            currentProduct.Description = "15-inch steel blade hand saw";
            currentProduct.ProductVendor.CompanyName = "ABC Corp";
            var expected = "Hello Saw (1): 15-inch steel blade hand saw" + 
                " Available on: ";

            // Act 
            var actual = currentProduct.SayHello();
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SayHelloParamConstructor()
        {
            // Arrange 
            var currentProduct = new Product(1, "Saw", "15-inch steel blade hand saw");

            var expected = "Hello Saw (1): 15-inch steel blade hand saw" +
                " Available on: ";
            
            // Act 
            var actual = currentProduct.SayHello();
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SayHello_ObjectInitializer()
        {
            // Arrange
            var currentProduct = new Product()
            {
                ProductId = 1,
                ProductName = "Saw",
                Description = "15-inch steel blade hand saw"
            };

            var expected = "Hello Saw (1): 15-inch steel blade hand saw" +
                " Available on: ";
            
            //Act
            var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);


        }

        [TestMethod()]
        public void Product_Null()
        {
            //Arrange
            Product currentProduct = null;
            var companyName = currentProduct?.ProductVendor?.CompanyName;

            string expected = null;

            //Act
            var actual = companyName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertMetersToInchesTest()
        {
            // Arrange
            var expected = 78.74;

            // Act

            var actual = 2 * Product.InchesPerMeter;

            // Assert
            
            Assert.AreEqual(expected, actual);
        }

    }
}