using ConvertMetric.Web.HttpRepository.Interfaces;
using ConvertMetric.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConvertMetric.Web.Controllers
{
    public class HomeController : Controller
    {
  
        private readonly ILengthRepository _lengthRepository;
        private readonly ITemparatureRepository _temparatureRepository;
        private readonly IWeightRepository _weightRepository;

        public HomeController(ILengthRepository lengthRepository,
            ITemparatureRepository temparatureRepository, 
            IWeightRepository weightRepository)
        {
            _lengthRepository = lengthRepository;
            _temparatureRepository = temparatureRepository;
            _weightRepository = weightRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
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