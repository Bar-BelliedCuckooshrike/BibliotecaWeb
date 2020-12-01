using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaWeb.Models
{
    [Table("Usuarios")]
    public class Usuario : BaseModel
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string PassWord { get; set; }
        public string Cep { get; set; }

        public int usuariolog { get; set; }

        public Usuario()
        {
            usuariolog = Id;
        }
    }
}
