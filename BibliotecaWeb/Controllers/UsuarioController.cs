using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaWeb.Models;
using Microsoft.AspNetCore.Identity;

namespace BibliotecaWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public UsuarioController(Context context, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }       
        
        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomeUsuario,SenhaUsuario,Id,CriadoEm,SenhaConfirm,Cep")] UsuarioView usuarioView)
        {
            
            if (ModelState.IsValid)
            {
                Usuario usuario = new Usuario()
                {
                    UserName = usuarioView.NomeUsuario,
                    Cep = usuarioView.Cep
                    
                };
                IdentityResult resultado = await _userManager.CreateAsync(usuario, usuarioView.SenhaUsuario);
                if (resultado.Succeeded)
                {
                    _context.Add(usuarioView);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                AddErrors(resultado);
            }
            return View(usuarioView);
        }

        public void AddErrors(IdentityResult resultado)
        {
            foreach (IdentityError erro in resultado.Errors)
            {
                ModelState.AddModelError("", erro.Description);
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("NomeUsuario,SenhaUsuario")] UsuarioView usuarioView)
        {
          var result = await _signInManager.PasswordSignInAsync(usuarioView.NomeUsuario, usuarioView.SenhaUsuario, 
              false, false);
            string name = _signInManager.Context.User.Identity.Name;
            if (result.Succeeded)
            {
                return RedirectToAction("CadastrarLivro", "Livro");
            }
            ModelState.AddModelError("", "Login ou senha inválidos!");
            return View(usuarioView);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Menu");
        }

    }
}
