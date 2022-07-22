using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierreVendor.Models;

namespace PierreVendor.Tests
{
    [TestClass]
    public class VendorTests : IDisposable
    {
        public void Dispose()
        {
            Vendor.ClearAll();
        }

        [TestMethod]
        public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
        {
            Vendor newVendor = new Vendor("test", "test 2");
            Assert.AreEqual(typeof (Vendor), newVendor.GetType());
        }

        [TestMethod]
        public void GetVendorName_Return_String()
        {
            string vendorName = "Test Vendor";
           
            Vendor newVendor = new Vendor(vendorName, "test");

            string result = newVendor.VendorName;
            Assert.AreEqual (vendorName, result);
        }

        [TestMethod]
        public void GetId_ReturnVendorId_Int()
        {
            string vendorName = "Test Vendor";
            Vendor newVendor = new Vendor(vendorName, "test");
            int result = newVendor.Id;
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetAll_ReturnsAllVendorObjects_VendorList()
        {
            string vendorName01 = "Test Vendor 1";
            string vendorName02 = "Test Vendor 2";
            Vendor newVendor1 = new Vendor(vendorName01, "test");
            Vendor newVendor2 = new Vendor(vendorName02, "test");
            List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };
            List<Vendor> result = Vendor.GetAll();
            CollectionAssert.AreEqual (newList, result);
        }

        [TestMethod]
        public void Find_ReturnsCorrectVendor_Vendor()
        {
            string vendorName01 = "Test Vendor 1";
            string vendorName02 = "Test Vendor 2";
            Vendor newVendor1 = new Vendor(vendorName01, "test");
            Vendor newVendor2 = new Vendor(vendorName02, "test");
            Vendor result = Vendor.Find(2);
            Assert.AreEqual (newVendor2, result);
        }

        [TestMethod]
        public void AddOrder_AssociatesOrderWithVendor_OrderList()
        {
            string orderName = "Test Order Name";
            string description = "test description";
            int price = 45;
            string date = "5/23/23";
            Order newOrder = new Order(orderName, description, price, date);
            List<Order> newList = new List<Order> { newOrder };
            string vendorName = "Pizza";
            string vendorInfo = "Very good pizza";
            Vendor newVendor = new Vendor(vendorName, vendorInfo);
            newVendor.AddOrder (newOrder);
            List<Order> result = newVendor.Orders;
            CollectionAssert.AreEqual (newList, result);
        }
    }
}
