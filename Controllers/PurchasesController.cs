using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelationsNaN.Data;
using RelationsNaN.Models;

namespace RelationsNaN.Controllers
{
    public class PurchasesController : Controller
    {
        private readonly RelationsNaNContext _context;

        public PurchasesController(RelationsNaNContext context)
        {
            _context = context;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            IEnumerable<Purchase> relationsNaNContext = await _context.Purchase.Include(p => p.GamePurchases).ThenInclude(gp => gp.Game).ToListAsync();
            return View(relationsNaNContext);
        }
    }
}
