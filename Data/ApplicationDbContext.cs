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
}
