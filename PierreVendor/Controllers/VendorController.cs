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

    
  }
}