using System.ComponentModel.DataAnnotations.Schema;

namespace TPEZANO.Models
{
    [Table("t_pago")]
    public class Pago
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        public DateTime PaymentDate { get; set; }

        public String NombreTarjeta { get; set; }

        public String NumeroTarjeta { get; set; }
        
        [NotMapped]
        public String DueDateYYMM { get; set; } // No se guarda en la BD

        [NotMapped]
        public String Cvv { get; set; }         // No se guarda en la BD

        public Decimal MontoTotal { get; set; }

        public String UserId { get; set; }
    }
}