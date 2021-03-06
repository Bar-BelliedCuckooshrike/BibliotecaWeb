﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BibliotecaWeb.DAL;
using BibliotecaWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaWeb.Controllers
{
    
    public class LivroController : Controller
    {
        private readonly LivroDAL _livroDAL;
        private readonly IWebHostEnvironment _hosting;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;


        public LivroController(LivroDAL livroDAL, IWebHostEnvironment hosting, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {

            _livroDAL = livroDAL;
            _hosting = hosting;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> BuscarData(DateTime? minDate, DateTime? maxDate)
        {
            var result = await _livroDAL.FindByDate(minDate, maxDate);
            return View(result);
        }

        public async Task<IActionResult> BuscarAutor(string autor)
        {
            var result = await _livroDAL.BuscarAutor(autor);
            return View(result);
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

            string IdUser = _signInManager.Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //Recebe os dados do formulário e salva-os.

            livro.UsuarioId = IdUser;
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
