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
            var repas = _context.Repas.ToList();
            return View(repas);
        }
    }
}
