using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPEZANO.Models
{
    [Table("t_producto")]
    public class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name {get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set;} 
        
        [Column("precio")]
        public Decimal Precio { get; set;}

        public string ImageName { get; set;}
    }
}