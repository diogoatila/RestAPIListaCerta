using RestAPIListaCerta.Context;
using RestAPIListaCerta.Models;
using RestAPIListaCerta.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestAPIListaCerta.Repository.Implementations
{
    public class CategoriaRepository : ICategoriaRepository
    {

        private volatile int count;

        private ListaContext _context;
        public CategoriaRepository(ListaContext context)
        {
            _context = context;
        }

        public List<Categoria> FindAll()
        {
            return _context.Categorias.ToList();
        }



        public Categoria FindById(int id)
        {
            return _context.Categorias.SingleOrDefault(c => c.CategoriaID == id);
        }
        public Categoria Create(Categoria categoria)
        {
            try
            {
                _context.Add(categoria);
                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
            return categoria;
        }
        public Categoria Update(Categoria categoria)
        {
            if (!Exists(categoria.CategoriaID)) return new Categoria();

            var result = _context.Categorias.SingleOrDefault(c => c.CategoriaID == categoria.CategoriaID);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(categoria);
                    _context.SaveChanges();

                }
                catch (Exception)
                {
                    throw;
                }
            }

            return categoria;
        }

        public void Delete(int id)
        {
            var result = _context.Categorias.SingleOrDefault(c => c.CategoriaID == id);
            if (result != null)
            {
                try
                {
                    _context.Categorias.Remove(result);
                    _context.SaveChanges();

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(int id)
        {
            return _context.Categorias.Any(c => c.CategoriaID == id);
        }
    }
}
