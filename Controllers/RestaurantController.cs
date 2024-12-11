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
        public IActionResult Add(string name, string location)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(location))
            {
                var newRestaurant = new Restaurant
                {
                    Name = name,
                    Location = location
                };
                _context.Repas.Add(newRestaurant); // Ajoute le nouveau restaurant
                _context.SaveChanges(); // Enregistre les modifications
            }
            return RedirectToAction(nameof(Index)); // Retourne à la liste après l'ajout
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var restaurant = _context.Repas.Find(id);
            if (restaurant != null)
            {
                _context.Repas.Remove(restaurant); // Supprime l'entrée de la base de données
                _context.SaveChanges(); // Enregistre les modifications
            }
            return RedirectToAction(nameof(Index)); // Retourne à la liste après suppression
        }
    }
}
