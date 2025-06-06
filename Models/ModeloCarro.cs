using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarrosWebApp.Models
{
    [Table("modelos_carros")]
    public class ModeloCarro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Marca é obrigatório.")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campo Marca é obrigatório.")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O campo Marca é obrigatório.")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "O campo Marca é obrigatório.")]
        public string Cor { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }
    }
}
