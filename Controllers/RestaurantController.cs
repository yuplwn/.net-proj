using Microsoft.AspNetCore.Mvc;
using mvcWithDb.Data;
using mvcWithDb.Models;

namespace mvcWithDb.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RestaurantController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var restaurants = _context.Repas.ToList();
            return View(restaurants);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var restaurant = _context.Repas.Find(id);
            if (restaurant != null)
            {
                _context.Repas.Remove(restaurant);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
