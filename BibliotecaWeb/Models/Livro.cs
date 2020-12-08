using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaWeb.Models
{

    [Table("Livros")]
    public class Livro : BaseModel
    { //colocar as validações
                
        public string Titulo { get; set; }
      
        public string Autor { get; set; }
      
        public string Editora { get; set; }
     
        public string Edicao { get; set; }
     
        public string NumPaginas { get; set; }
    
        public string Isbn { get; set; }

        public string imagem { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
       
        public string UsuarioId { get; set; }

    }
}
