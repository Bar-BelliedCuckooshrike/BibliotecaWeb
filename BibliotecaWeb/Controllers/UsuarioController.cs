using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaWeb.DAL;
using BibliotecaWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly LivroDAL _livroDAL;
        private readonly UsuarioDAL _usuarioDAL;

        public UsuarioController(LivroDAL livroDAL, UsuarioDAL usuarioDAL)
        {
            _livroDAL = livroDAL;
            _usuarioDAL = usuarioDAL;
        }

        public IActionResult Index()
        {            
            return View();
        }

        public IActionResult CadastrarUsuario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(Usuario usuario)
        {
            if (_usuarioDAL.CadastrarUsuario(usuario))
            {
                return RedirectToAction("Index", "Menu");
            }
            ModelState.AddModelError("", "Esse usuário já existe!");
            return View(usuario);
        }

        public IActionResult LoginUsuario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginUsuario(Usuario usuario)
        {
            if (_usuarioDAL.Login(usuario))
            {
                return RedirectToAction("CadastrarLivro", "Livro");
            }
            ModelState.AddModelError("", "Login ou senha incorretos. Tente Novamente!");
            return View();
        }
    }
}
