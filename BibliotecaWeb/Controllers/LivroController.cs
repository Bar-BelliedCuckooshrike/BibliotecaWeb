using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaWeb.DAL;
using BibliotecaWeb.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaWeb.Controllers
{
    public class LivroController : Controller
    {
        private readonly LivroDAL _livroDAL;
        private readonly IWebHostEnvironment _hosting;
        private readonly UsuarioDAL _usuarioDAL;

        public LivroController(LivroDAL livroDAL, IWebHostEnvironment hosting, UsuarioDAL usuarioDAL)
        {

            _livroDAL = livroDAL;
            _hosting = hosting;
            _usuarioDAL = usuarioDAL;
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
        public IActionResult CadastrarLivro(Livro livro, IFormFile file) //<- IFormFile é para arquivos.
        {
            Usuario usuario = new Usuario();

            if (file != null)
            { //salva uma imagem.
                string arquivo = Path.GetFileName(file.FileName);
                string caminho = Path.Combine(_hosting.WebRootPath, "images", arquivo);
                file.CopyTo(new FileStream(caminho, FileMode.Create));
                livro.imagem = arquivo;
            }
            else
            { //se não houver imagem, adiciona essa imagem.
                livro.imagem = "noimageavailable.jpg";
            }

            livro.usuariologado = UsuarioDAL.UsuarioLogadoGET();

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
