﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaWeb.Controllers
{
    public class LivroController : Controller
    {
        private readonly Context _context;

        public LivroController(Context context)
        {
            _context = context;
        }

        public IActionResult CadastrarLivro()   
        {
            List<Livro> livros = _context.Livros.ToList();
            ViewBag.Livros = livros;
            ViewBag.DataHora = DateTime.Now;
            return View();
        }

        public IActionResult Remover(int id)
        {
            //Completar com o código da remoção.
            return RedirectToAction("Index", "Menu");
        }

        [HttpPost]
        public IActionResult CadastrarLivro(string TxtTitulo, string TxtAutor, string TxtEditora,
            string TxtEdicao, string TxtPaginas, string TxtISBN)
        {
            //Recebe os dados do formulário e salva-os.
            Livro livro = new Livro
            {
                Titulo = TxtTitulo,
                Autor = TxtAutor,
                Editora = TxtEditora,
                Edicao = TxtEdicao,
                NumPaginas = TxtPaginas,
                Isbn = TxtISBN
            };

            _context.Livros.Add(livro);
            _context.SaveChanges();

            //Após salvar, o usuário é redirecionado para a página principal.
            return RedirectToAction("Index", "Menu");
        }
    }
}