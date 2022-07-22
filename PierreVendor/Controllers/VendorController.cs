using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PierreVendor.Models;

namespace PierreVendor.Controllers
{
    public class VendorController : Controller
    {
        [HttpGet("/vendors")]
        public ActionResult Index()
        {
            List<Vendor> allVendors = Vendor.GetAll();
            return View(allVendors);
        }

        [HttpGet("/vendors/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/vendors")]
        public ActionResult Create(string vendorName, string title)
        {
            Vendor newVendor = new Vendor(vendorName, title);
            return RedirectToAction("Index");
        }

        [HttpGet("/vendors/{id")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Vendor selectedVendor = Vendor.Find(id);
            List<Order> vendorOrders = selectedVendor.Orders;
            model.Add("vendor", selectedVendor);
            model.Add("orders", vendorOrders);
            return View(model);
        }

        [HttpPost("/vendors/{vendorsId}/orders")]
        public ActionResult
        Create(
            int vendorId,
            string orderTitle,
            string orderDescription,
            int orderPrice,
            string orderDate
        )
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Vendor foundVendor = Vendor.Find(vendorId);
            Order newOrder =
                new Order(orderTitle, orderDescription, orderPrice, orderDate);
            foundVendor.AddOrder (newOrder);
            List<Order> vendorOrder = foundVendor.Orders;
            model.Add("orders", vendorOrder);
            model.Add("vendor", foundVendor);
            return View("Show", model);
        }
    }
}
