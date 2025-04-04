using System.ComponentModel.DataAnnotations;

namespace ProjetoAviao.Models
{
    public class AviaoView
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "campo obrigatorio da aviação")]
        public string? Aviacao { get; set; }

        [Required(ErrorMessage = "campo obrigatorio do Tipo")]
        public string? Tipo { get; set; }

        [Required(ErrorMessage = "campo obrigatorio da origem")]
        public string? Origem { get; set; }

        [Required(ErrorMessage = "campo obrigatorio da conexao")]
        public string? Conexao { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio do destino")]
        public string? Destino { get; set; }
    }
}
