using BibliotecaWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaWeb.DAL
{
    public class LivroDAL
    {
        private readonly Context _context;

        public LivroDAL(Context context)
        {
            _context = context;
        }

        //public List<Livro> GetByUsuario(int id)
        //{
        //    return _context.Livros.Where(x => x.UsuarioId == id).ToList();
        //}

        public Livro BuscarPorISBN(string isbn)
        {
           return _context.Livros.FirstOrDefault(x => x.Isbn == isbn);
        }

        public List<Livro> Listar()
        {
           return _context.Livros.ToList();
        }

        public async Task<List<Livro>> FindByDate(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Livros select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.CriadoEm >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.CriadoEm <= maxDate.Value);
            }
            return await result.OrderByDescending(x => x.CriadoEm).ToListAsync();
        }

        public Livro BuscarPorId(int id)
        {
            return _context.Livros.Find(id);
        }

        public bool CadastrarLivro(Livro livro)
        {
            if (BuscarPorISBN(livro.Isbn) == null)
            {                
                _context.Livros.Add(livro);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Remover(int id)
        {
            _context.Livros.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }

        public void Alterar(Livro livro)
        {
            _context.Livros.Update(livro);
            _context.SaveChanges();
        }
    }
}
