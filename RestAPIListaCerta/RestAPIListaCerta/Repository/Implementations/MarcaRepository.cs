using RestAPIListaCerta.Context;
using RestAPIListaCerta.Models;
using RestAPIListaCerta.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestAPIListaCerta.Repository.Implementations
{
    public class MarcaRepository : IMarcaRepository
    {

        private volatile int count;

        private ListaContext _context;
        public MarcaRepository(ListaContext context)
        {
            _context = context;
        }

        public List<Marca> FindAll()
        {
            return _context.Marcas.ToList();
        }



        public Marca FindById(int id)
        {
            return _context.Marcas.SingleOrDefault(m => m.MarcaID == id);
        }
        public Marca Create(Marca marca)
        {
            try
            {
                _context.Add(marca);
                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
            return marca;
        }
        public Marca Update(Marca marca)
        {
            if (!Exists(marca.MarcaID)) return new Marca();

            var result = _context.Marcas.SingleOrDefault(m => m.MarcaID == marca.MarcaID);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(marca);
                    _context.SaveChanges();

                }
                catch (Exception)
                {
                    throw;
                }
            }

            return marca;
        }

        public void Delete(int id)
        {
            var result = _context.Marcas.SingleOrDefault(m => m.MarcaID == id);
            if (result != null)
            {
                try
                {
                    _context.Marcas.Remove(result);
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
            return _context.Marcas.Any(m => m.MarcaID == id);
        }
    }
}
