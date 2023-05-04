using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TPEZANO.Models;
using TPEZANO.Data; 
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Dynamic;

namespace TPEZANO.Controllers
{
    public class ProformaController: Controller
    {


        private readonly ILogger<CatalogoController> _logger;

        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        public ProformaController(ApplicationDbContext context, ILogger<CatalogoController> logger, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _logger = logger;   
            _userManager = userManager;   
        }

        public IActionResult Index()
        {
            var userIDSession = _userManager.GetUserName(User);
           
            var items = from o in _context.DataProforma select o;
            items = items.Include(p => p.producto).
                    Where(w => w.UserID.Equals(userIDSession) &&
                     w.Status.Equals("PENDIENTE"));
            var itemsCarrito = items.ToList();
            
            var total = itemsCarrito.Sum(c => c.Quantity * c.Price);
            
            dynamic model = new ExpandoObject();
            model.montoTotal = total;
            model.elementosCarrito = itemsCarrito;

        
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proforma = await _context.DataProforma.FindAsync(id);
            if (proforma == null)
            {
                return NotFound();
            }
            return View(proforma);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantity,Price,UserID")] Proforma proforma)
        {
            if (id != proforma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proforma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.DataProforma.Any(e => e.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(proforma);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proforma = await _context.DataProforma.FindAsync(id);
            _context.DataProforma.Remove(proforma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        
    }
}