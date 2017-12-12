using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random() //returns the action result
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandoMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);

            //return View(movie); //1.passing the model to View method
            //ViewData["Movie"] = movie; //2. using ViewData(ViewDataDictionary)
            //return View();
            //ViewBag.Movie = movie; //3. ViewBag

        }

        [Route("movies/{id}")]
        public ActionResult EditMovie(int id)
        {
           return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;


            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content($"pageIndex={pageIndex}&sortBy={sortBy}");
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        [Route("movies")]
        public ActionResult MoviesList()
        {
            var movies = new List<Movie>()
            {
                new Movie {Id = 1, Name = "Shrek"},
                new Movie {Id = 2, Name = "Dino World"}
            };

            var viewModel = new MoviesCustomersViewModel()
            {
                Movies = movies
            };

            return View(viewModel);

        }

        

    }
}
