using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atividade_1.Models
{
    [Table("Culturas")]
    public class Cultura
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(35)]
        public string nome { get; set; }

        [Required]
        [StringLength(40)]
        public string tipo { get; set; }

        [Required]
        public double area { get; set; }

        public string descricao { get; set; }

    }
}
