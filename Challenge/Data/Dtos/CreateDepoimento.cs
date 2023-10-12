using System.ComponentModel.DataAnnotations;

namespace Challenge.Data.Dtos
{
    public class CreateDepoimento
    {
        public string Foto { get; set; }

        [Required(ErrorMessage = "O depoimento é obrigatorio.")]
        [MaxLength(150, ErrorMessage = "O tamanho do depoimento não pode exceder 150 caracteres.")]
        public string Depoimento { get; set; }

        public string Nome { get; set; }
    }
}