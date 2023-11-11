using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.Common;
using tutor1.Models;

namespace tutor1.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly IDbConnection _dbConnection;

        public AnimalsController(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var animals = _dbConnection.Query<AnimalModel>("Select * From Animals");

            var viewModel = new AnimalsViewModel()
            {
                Animals = animals.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(AnimalsViewModel viewmodel)
        {
            if (ModelState.IsValid == false) 
            {
                var animals = _dbConnection.Query<AnimalModel>("Select * From Animals");
                viewmodel.Animals = animals.ToList();
                return View("Index", viewmodel);
            }

            var sql = "INSERT INTO Animals (Name, Color, Age, Extinct)" +
                      "VALUES (@Name, @Color, @Age, @Extinct);";

            var parameters = new
            {
                Name = viewmodel.Name,
                Color = viewmodel.Color,
                Age = viewmodel.Age,
                Extinct = viewmodel.Extinct
            };

            _dbConnection.Execute(sql, parameters);

            return RedirectToAction("Index");

        }

        public IActionResult ClearTable(AnimalsViewModel viewmodel)
        {
            var sql = "DELETE FROM Animals";
            _dbConnection.Execute(sql);
            return RedirectToAction("Index");
        }
    }

}