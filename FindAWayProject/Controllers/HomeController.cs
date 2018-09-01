using FindAWayProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FindAWayProject.Controllers
{
    public class HomeController : Controller
    {
        public IPathService Service;

        public HomeController(IPathService service)
        {
            Service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult StartGame()
        {
            return Json(Service.GeneratePath());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VerifyPosition(int column, int line, string guid)
        {
            var newGuid = Guid.Parse(guid);
            return Json(Service.GetBlock(column, line, newGuid));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckFullPath(string guid)
        {
            var newGuid = Guid.Parse(guid);
            return Json(Service.GetFullPath(newGuid));
        }
    }
}