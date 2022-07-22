using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierreVendor.Models;

namespace PierreVendor.Tests
{
    [TestClass]
    public class PierreVendorTests : IDisposable
    {
        public void Dispose()
        {
            Vendor.ClearAll();
        }

        [TestMethod]
        public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
        {
            Vendor newVendor = new Vendor("test");
            Assert.AreEqual(typeof (Vendor), newVendor.GetType());
        }

        [TestMethod]
        public void GetVendorName_Return_String()
        {
            string vendorName = "Test Vendor";
            Vendor newVendor = new Vendor(vendorName);

            string result = newVendor.VendorName;
            Assert.AreEqual(vendorName, result);
        }

        [TestMethod]
        public void GetId_ReturnVendorId_Int()
        {
            string vendorName = "Test Vendor";
            Vendor newVendor = new Vendor(vendorName);
            int result = newVendor.Id;
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetAll_ReturnsAllVendorObjects_VendorList()
        {
            string vendorName01 = "Test Vendor 1";
            string vendorName02 = "Test Vendor 2";
            Vendor newVendor1 = new Vendor(vendorName01);
            Vendor newVendor2 = new Vendor(vendorName02);
            List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2};
            List<Vendor> result = Vendor.GetAll();
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void Find_ReturnsCorrectVendor_Vendor()
        {
            string vendorName01 = "Test Vendor 1";
            string vendorName02 = "Test Vendor 2";
            Vendor newVendor1 = new Vendor(vendorName01);
            Vendor newVendor2 = new Vendor(vendorName02);
            Vendor result = Vendor.Find(2);
            Assert.AreEqual(newVendor2, result);
        }

      
    }
}