using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TPEZANO.Models;
using TPEZANO.Data; 
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace TPEZANO.Controllers
{
    public class CatalogoController : Controller
    {
        
            
        private readonly ILogger<CatalogoController> _logger;

        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        public CatalogoController(ApplicationDbContext context, ILogger<CatalogoController> logger, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _logger = logger;   
            _userManager = userManager;   
        }

        public async Task<IActionResult> Index(string? searchString)
        {
            var productos = from o in _context.DataProductos select o;

            if(!String.IsNullOrEmpty(searchString)){
                productos = productos.Where(s => s.Name.Contains(searchString));
            }

            return View(await productos.ToListAsync());
        }
        
        public async Task<IActionResult> Details(int? id){
            Producto objProd = await _context.DataProductos.FindAsync(id);

            if(objProd == null){
                return NotFound();
            }
            return View(objProd);
        }
        public async Task<IActionResult> Add(int? id){
            var userID = _userManager.GetUserName(User);
            if(userID == null){
                ViewData["Message"] = "Debe Iniciar Sesion antes de agregar un producto";
                List<Producto> productos = new List<Producto>();
                return View("Index", productos);
            }else{
                var producto = await _context.DatProductos.FindAsync(id);
                Proforma proforma = new Proforma();
                proforma.producto = producto;
                proforma.Price = producto.Precio;
                proforma.Quantity = 1;
                proforma.UserID = userID;
                _context.Add(proforma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }


    }
}
