using RestAPIListaCerta.Context;
using RestAPIListaCerta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIListaCerta.Repository.Implementations
{
    public class ProdutoRepository : IProdutoRepository
    {
        private ListaContext _context;

        public ProdutoRepository(ListaContext context)
        {
            _context = context;
        }
        public Produto FindByID(int id)
        {
            return _context.Produtos.SingleOrDefault(p => p.ProdutoID.Equals(id));
        }
        public List<Produto> FindAll()
        {
            return _context.Produtos.ToList();
        }
        public Produto Create(Produto produto)
        {
            try
            {
                _context.Add(produto);
                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
            return produto;
        }

        public void Delete(int id)
        {
            var result = _context.Produtos.SingleOrDefault(p => p.ProdutoID == id);
            if (result != null)
            {
                try
                {
                    _context.Produtos.Remove(result);
                    _context.SaveChanges();

                }
                catch (Exception)
                {
                    throw;
                }
            };
        }

        public bool Exists(int id)
        {
            return _context.Produtos.Any(p => p.ProdutoID == id);
        }      

        public Produto Update(Produto produto)
        {
            if (!Exists(produto.ProdutoID)) return new Produto();

            var result = _context.Produtos.SingleOrDefault(p =>p.ProdutoID == produto.ProdutoID);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(produto);
                    _context.SaveChanges();

                }
                catch (Exception)
                {
                    throw;
                }
            }

            return produto;
        }
    }
}
