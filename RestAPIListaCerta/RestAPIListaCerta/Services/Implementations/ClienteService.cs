using RestAPIListaCerta.Context;
using RestAPIListaCerta.Models;
using RestAPIListaCerta.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestAPIListaCerta.Services.Implementations
{
    public class ClienteService : IClienteService
    {

        private volatile int count;

        private ListaContext _context;
        public ClienteService(ListaContext context)
        {
            _context = context;
        }

        public List<Cliente> FindAll()
        {
            return _context.Clientes.ToList();
        }



        public Cliente FindById(int id)
        {
            return _context.Clientes.SingleOrDefault(c => c.ClienteID == id);
        }
        public Cliente Create(Cliente cliente)
        {
            try
            {
                _context.Add(cliente);
                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
            return cliente;
        }
        public Cliente Update(Cliente cliente)
        {
            if (!Exists(cliente.ClienteID)) return new Cliente();

            var result = _context.Clientes.SingleOrDefault(c => c.ClienteID == cliente.ClienteID);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(cliente);
                    _context.SaveChanges();

                }
                catch (Exception)
                {
                    throw;
                }
            }

            return cliente;
        }

        public void Delete(int id)
        {
            var result = _context.Clientes.SingleOrDefault(c => c.ClienteID == id);
            if (result != null)
            {
                try
                {
                    _context.Clientes.Remove(result);
                    _context.SaveChanges();

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private bool Exists(int id)
        {
            return _context.Clientes.Any(c => c.ClienteID == id);
        }
    }
}
