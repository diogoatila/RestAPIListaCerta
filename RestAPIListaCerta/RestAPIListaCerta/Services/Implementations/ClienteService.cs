using RestAPIListaCerta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestAPIListaCerta.Services.Implementations
{
    public class ClienteService : IClienteService
    {

        private volatile int count;
        public Cliente Create(Cliente cliente)
        {
            return cliente;
        }

        public void Delete(long id)
        {
            
        }

        public List<Cliente> GetAll()
        {
            List<Cliente> clientes = new List<Cliente>();
            for(int i = 0; i<8; i++)
            {
                Cliente cliente = MockCliente(i);
                clientes.Add(cliente);
            }
            return clientes; 
        }

       

        public Cliente GetById(long id)
        {
            return new Cliente
            {
                Id = IncrementAndGet(),
                FirstName = "Diogo",
                LastName = "Carvalho",
                Email = "diogoar57@gmail.com",
                Document = "39518367841",
                Gender = "Masculino"
            };
        }

        public Cliente Update(Cliente cliente)
        {
            return cliente;
        }

        private Cliente MockCliente(int i)
        {
            return new Cliente
            {
                Id = IncrementAndGet(),
                FirstName = "FirstName Cliente" + i,
                LastName = "LastName Cliente" + i,
                Email = "Email Cliente" + i,
                Document = "Document Cliente" + i,
                Gender = "Masculino" + i
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
