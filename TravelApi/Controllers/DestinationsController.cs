using Microsoft.AspNetCore.Mvc;
using TravelApi.Models;

namespace TravelApi.Controllers
{
  public class DestinationsController : Controller
    {
        public IActionResult Index()
        {
            var allDestinations = Destination.GetDestinations();
            return View(allDestinations);
        }

        public IActionResult Details(int id)
        {
            Destination destination = Destination.GetDetails(id);
            return View(destination);

        }
        public ActionResult Create()
        {
          return View();
        }

        [HttpPost]
        public ActionResult Create(Destination destination)
        {
            Destination.Post(destination);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var destination = Destination.GetDetails(id);
            return View(destination);    
        }
        [HttpPost]
        public IActionResult Edit(int id, Destination destination)
        {
           destination.DestinationId = id;
           Destination.Put(destination);
           return RedirectToAction("Index", id);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Destination.Delete(id);
            return RedirectToAction("Index");
        }
    }
}