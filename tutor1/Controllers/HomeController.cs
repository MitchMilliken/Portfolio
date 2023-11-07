using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using tutor1.Models;

namespace tutor1.Controllers
{
    public class HomeController : Controller
    {

        //public IActionResult Products(int? page, int? categoryId, string searchName = "", string sortOrder = "")
        //{
        //    int pageSize = 1;
        //    int pageNumber = (page ?? 1);

        //    ViewBag.SearchName = searchName;
        //    ViewBag.CategoryId = categoryId;
        //    ViewBag.SortOrder = sortOrder;
        //    //....
        //}
        //public async Task<IActionResult> Dropdown()
        //{
        //    ViewBag.CategoryId = 1;
        //    ViewBag.SearchName = "aaa";
        //    return View();
        //}

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            PersonModel chart = new PersonModel();

            List<PersonModel> persons = new List<PersonModel> {
                new PersonModel {
                    FirstName = "Jeff",
                    LastName = "Bridges"

                },
                 new PersonModel {
                    FirstName = "Lukas",
                    LastName = "Lippy"

                },
                new PersonModel
                {
                    FirstName = "Mitch",
                    LastName = "Milliken"

                },

            };

            List<CarModel> cars = new List<CarModel> {

                new CarModel {
                Color = "Red",
                Year = 2004
                },

                new CarModel {
                Color = "Black",
                Year = 2006
                },

                new CarModel {
                Color = "Grey",
                Year = 2011
                }

            };

            List<DogModel> dogs = new List<DogModel> {

                new DogModel {
                Fur = "Yellow",
                Breed = "Pitbull",
                },

                new DogModel {
                Fur = "Blue",
                Breed = "Husky"
                },

                new DogModel {
                Fur = "Pink",
                Breed = "Barker"

                }

            };




            IndexViewModel viewModel = new IndexViewModel
            {
                Cars = cars,
                Persons = persons,
                Dogs = dogs
            };


            return View(viewModel);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Tools()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}