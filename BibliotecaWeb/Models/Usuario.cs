using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaWeb.Models
{
    [Table("Usuarios")]
    public class Usuario : BaseModel
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
