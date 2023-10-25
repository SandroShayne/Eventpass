using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPass1.Models
{
    [Table("Ingressos")]
    public class Ingresso
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EventoId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [ForeignKey("EventoId")]
        public Evento Evento { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
    }
}

