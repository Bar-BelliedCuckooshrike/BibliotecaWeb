using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaWeb.Models
{
    [Table("Usuarios")]
    public class UsuarioView : BaseModel
    {
        [Display(Name ="Nome de usuário")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string NomeUsuario { get; set; }

        [Display(Name ="Senha")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string SenhaUsuario { get; set; }

        [NotMapped]
        [Display(Name ="Confirmar senha")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Compare("SenhaUsuario", ErrorMessage ="Os valores são diferentes!")]
        public string SenhaConfirm { get; set; }

        [Display(Name ="Cep")]
        [Required(ErrorMessage ="Campo obrigatório")]
        public string Cep { get; set; }

    }
}
