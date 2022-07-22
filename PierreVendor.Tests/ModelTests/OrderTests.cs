using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierreOrder.Models;

namespace PierreOrder.Tests
{
    [TestClass]
    public class OrderTests : IDisposable
    {
        public void Dispose()
        {
            Order.ClearAll();
        }

        [TestMethod]
        public void OrderConstructor_CreatesInstanceOfOrder_Order()
        {
            Order newOrder = new Order("test name", "Test Description", 34, "5/23/34");
            Assert.AreEqual(typeof (Order), newOrder.GetType());
        }

        [TestMethod]
        public void GetId_ReturnsOrderId_int()
        {
            string orderName = "Test Order Name";
            string description = "test description";
            int price = 45;
            string date = "5/23/23";
            Order newOrder = new Order(orderName, description, price, date);

            int result = newOrder.Id;
            Assert.AreEqual(0, result);
        }


        [TestMethod]
        public void GetAll_ReturnsOrderObjects_OrderList()
        {
            Order newOrder1 = new Order("test name", "Test Description", 34, "5/23/34");
            Order newOrder2 = new Order("test name 2", "test description 2", 24, "5/34/45");
            List<Order> newList = new List<Order> { newOrder1, newOrder2};
            List<Order> result = Order.GetAll();
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void Find_ReturnsCorrectOrder_Order()
        {
            Order newOrder1 = new Order("test name", "Test Description", 34, "5/23/34");
            Order newOrder2 = new Order("test name 2", "test description 2", 24, "5/34/45");
            Order result = Order.Find(2);
            Assert.AreEqual(newOrder2, result);
        }

       
    }
}
