using RestAPIListaCerta.Models;
using System.Collections.Generic;


namespace RestAPIListaCerta.Services
{
   public interface IClienteService
    {
        Cliente Create(Cliente cliente);
        Cliente GetById(long id);
        List<Cliente> GetAll();
        Cliente Update(Cliente cliente);
        void Delete(long id);

    }
}
