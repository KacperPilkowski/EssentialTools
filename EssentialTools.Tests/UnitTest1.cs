using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EssentialTools.Models;

namespace EssentialTools.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IDiscountHelper getTestObject()
        {
            return new MinimumDiscountHelper();
        }

        [TestMethod]
        public void Discount_Above_100()
        {
            //preparation
            IDiscountHelper target = getTestObject();
            decimal total = 200;

            //ACTION
            var discountedTotal = target.ApplyDecimal(total);

            //assertions
            Assert.AreEqual(total*0.9M, discountedTotal);
        }

        [TestMethod]
        public void Discount_Between_10_And_100()
        {
            // preparation
            IDiscountHelper target = getTestObject();

            //ACTION
            decimal TenDollarDiscount = target.ApplyDecimal(10);
            decimal HundredDollarDiscount = target.ApplyDecimal(100);
            decimal FidtyDollarDiscount = target.ApplyDecimal(50);

            //assertions
            Assert.AreEqual(5, TenDollarDiscount, "rabat w wysokości 10zł jest nieprawidłowy");
            Assert.AreEqual(95,HundredDollarDiscount, "rabat w wysokości 100zł jest nieprawidłowy");
            Assert.AreEqual(45, FidtyDollarDiscount, "rabat w wysokości 50zł jest nieprawidłowy");
        }

        [TestMethod]
        public void Diesount_Less_Then_10()
        {
            // preparation
            IDiscountHelper target = getTestObject();

            //ACTION
            decimal discount5 = target.ApplyDecimal(5);
            decimal discount0 = target.ApplyDecimal(0);

            //assertions
            Assert.AreEqual(5, discount5);
            Assert.AreEqual(0, discount0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Discount_Negative_Total()
        {
            // preparation
            IDiscountHelper target = getTestObject();
            
            //assertions
            target.ApplyDecimal(-1);
        }
    }
}
