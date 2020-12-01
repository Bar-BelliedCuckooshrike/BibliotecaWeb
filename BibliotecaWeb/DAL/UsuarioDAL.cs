using BibliotecaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaWeb.DAL
{
    public class UsuarioDAL
    {
        private readonly Context _context;
        public Usuario usuario1;

        public UsuarioDAL(Context context)
        {
            _context = context;
        }

        public Usuario GetByName(string Nome)
        {
            return _context.Usuarios.FirstOrDefault(x => x.UserName == Nome);
        }

        public Usuario GetBySenha(string senha)
        {
            return _context.Usuarios.FirstOrDefault(x => x.PassWord == senha);
        }

        public bool Login(Usuario usuario)
        {
            if (GetByName(usuario.UserName) != null)
            {
                if (GetBySenha(usuario.PassWord) != null)
                {
                    return true;
                }
                
            }
            return false;
        }

        public bool CadastrarUsuario(Usuario usuario)
        {
            if (GetByName(usuario.UserName) == null)
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        static Usuario usuariologado = new Usuario();

        public static void UsuarioLogadoSET(Usuario usuario)
        {
            usuariologado = usuario;
        }

        public static int UsuarioLogadoGET()
        {
            return usuariologado.Id;
        }

    }
}
