using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierreVendor.Models;

namespace PierreVendor.Tests
{
    [TestClass]
    public class PierreVendorTests 
    // : IDisposable
    {
        // public void Dispose()
        // {
        //     Vendor.ClearAll();
        // }

        [TestMethod]
        public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
        {
            Vendor newVendor = new Vendor("test");
            Assert.AreEqual(typeof (Vendor), newVendor.GetType());
        }
    }
}
