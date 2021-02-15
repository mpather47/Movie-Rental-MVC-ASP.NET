using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_2.Models;
using Vidly_2.ViewModels;

namespace Vidly_2.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new List<Movie>
            {
                
            };

            //Action Results
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            

            return View(viewModel);
            
            
            //return Content("Hello World"); - returns simple text
            //return HttpNotFound(); - returns 404 error
            // return new EmptyResult(); - returns nothing
            //return RedirectToAction("Index", "Home", new { page =1 , sortBy ="name"});
            
        }

        public ActionResult List() {
            var movie = new List<Movie>
            {
                new Movie { Name = "Shrek 1"},
                new Movie { Name = "Shrek 2"},
                new Movie { Name = "Shrek 3"},
                new Movie { Name = "Shrek 4"}
            };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };


            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }
        //Movies
        [Route("movies/Customers/Details/{id}")]
        public ActionResult Retrieve(int? id, string sortBy)
        {
            var customer = new Customer();
            if (!id.HasValue)
                id = 1;
            
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", id, sortBy));

        }
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year +"/"+month);

        }

    }
}