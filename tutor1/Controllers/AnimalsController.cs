using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
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
    }
}
