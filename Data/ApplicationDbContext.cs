using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TPEZANO.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<TPEZANO.Models.Contacto> DataContactos { get; set; }

     public DbSet<TPEZANO.Models.Producto> DataProductos { get; set;}

     public DbSet<TPEZANO.Models.Proforma> DataProforma { get; set;}

    public DbSet<TPEZANO.Models.Pago> DataPago { get; set;}

    public DbSet<TPEZANO.Models.Pedido> DataPedido { get; set;}
    
    public DbSet<TPEZANO.Models.DetallePedido> DataDetallePedido { get; set; }
}
