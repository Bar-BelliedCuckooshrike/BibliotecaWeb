﻿using BibliotecaWeb.Models;
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

        public Livro BuscarPorISBN(string isbn)
        {
           return _context.Livros.FirstOrDefault(x => x.Isbn == isbn);
        }

        public List<Livro> Listar()
        {
           return _context.Livros.ToList();
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
