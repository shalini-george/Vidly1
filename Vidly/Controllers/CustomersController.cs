using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        [Route("customers")]
        public ActionResult CustomersList()
        {
            var customers = new List<Customer>()
            {
                new Customer{Id = 1, Name = "Customer1"},
                new Customer {Id = 2, Name = "Customer 2"}
            };

            var viewModel = new MoviesCustomersViewModel
            {
                Customers = customers
            };
            return View(viewModel);
        }

        [Route("customers/{id}")]
        public ActionResult EditCustomer(int id)
        {
            return Content("id=" + id);
        }
    }
}