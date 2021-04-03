using RestAPIListaCerta.Context;
using RestAPIListaCerta.Models;
using RestAPIListaCerta.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestAPIListaCerta.Repository.Implementations
{
    public class ListaRepository : IListaRepository
    {

        private volatile int count;

        private ListaContext _context;
        public ListaRepository(ListaContext context)
        {
            _context = context;
        }

        public List<Lista> FindAll()
        {
            return _context.Listas.ToList();
        }



        public Lista FindById(int id)
        {
            return _context.Listas.SingleOrDefault(l => l.ListaID == id);
        }
        public Lista Create(Lista lista)
        {
            try
            {
                _context.Add(lista);
                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
        public Lista Update(Lista lista)
        {
            if (!Exists(lista.ListaID)) return new Lista();

            var result = _context.Listas.SingleOrDefault(l => l.ListaID == lista.ListaID);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(lista);
                    _context.SaveChanges();

                }
                catch (Exception)
                {
                    throw;
                }
            }

            return lista;
        }

        public void Delete(int id)
        {
            var result = _context.Listas.SingleOrDefault(l => l.ListaID == id);
            if (result != null)
            {
                try
                {
                    _context.Listas.Remove(result);
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
            return _context.Listas.Any(l => l.ListaID == id);
        }
    }
}
