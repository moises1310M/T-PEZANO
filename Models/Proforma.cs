using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPEZANO.Models
{
     [Table("t_proforma")]
    public class Proforma
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        

        public String UserID { get; set; }

        public Producto producto { get; set; }

        public int Quantity { get; set; }

        public Decimal Price { get  ;set; }

        public String Status { get; set; } = "PENDIENTE";

    }
}