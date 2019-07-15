using Microsoft.VisualStudio.TestTools.UnitTesting;
using ecommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Need to add reference: assemblyref://Microsoft.VisualStudio.QualityTools.UnitTestFramework
// for this to work properly

namespace ecommerce.Tests
{
    [TestClass()]
    public class CartTests
    {
        [TestMethod()]
        public void addProductTest()
        {
            Cart c = new Cart(123, 123);
            Assert.AreEqual(c.numberOfProducts(), 0);
            c.addProduct(new Product());
            Assert.AreEqual(c.numberOfProducts(), 1);

            c.addProduct(new Product(int.MaxValue));
            Assert.AreEqual(c.GetProducts()[1].productID, int.MaxValue);
        }

        [TestMethod()]
        public void removeProductTest()
        {
            Cart c = new Cart(123);
            c.addProduct(new Product());
            c.removeProduct(new Product());
            Assert.AreEqual(c.numberOfProducts(), 0);
        }

    }
}