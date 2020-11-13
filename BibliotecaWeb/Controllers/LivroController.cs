using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaWeb.DAL;
using BibliotecaWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaWeb.Controllers
{
    public class LivroController : Controller
    {
        private readonly LivroDAL _livroDAL;

        public LivroController(LivroDAL livroDAL)
        {
            _livroDAL = livroDAL;
        }

        public IActionResult Remover(int id)
        {
            _livroDAL.Remover(id);
            return RedirectToAction("Index", "Menu");
        }

        public IActionResult Alterar(int id)
        {
            return View(_livroDAL.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Livro livro)
        {
            //Recebe os dados do formulário e salva-os.
            _livroDAL.Alterar(livro);

            //Após salvar, o usuário é redirecionado para a página principal.
            return RedirectToAction("Index", "Menu");
        }

        public IActionResult CadastrarLivro()
        {
            List<Livro> livros = _livroDAL.Listar();
            ViewBag.Livros = livros;
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarLivro(Livro livro)
        {
            //Recebe os dados do formulário e salva-os.

            if (_livroDAL.CadastrarLivro(livro))
            {
                //Após salvar, o usuário é redirecionado para a página principal.
                return RedirectToAction("Index", "Menu");
            }
            ModelState.AddModelError("", "Não foi possível cadastrar o livro!");
            return View(livro);
        }
    }
}
