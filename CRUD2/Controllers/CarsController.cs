using CRUD2.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUD2.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        public async Task <IActionResult> Index()
        {
            var cars = await _carService.GetCarsAsync();
            return View(cars);
        }
    }
}
