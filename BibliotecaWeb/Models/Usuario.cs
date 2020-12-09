using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaWeb.Models
{
    public class Usuario : IdentityUser
    {
        public string Cep { get; set; }

        public List<Livro> livros { get; set; }

    }
}
