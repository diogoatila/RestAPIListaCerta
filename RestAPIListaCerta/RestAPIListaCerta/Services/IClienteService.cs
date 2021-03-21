using RestAPIListaCerta.Models;
using System.Collections.Generic;


namespace RestAPIListaCerta.Services
{
   public interface IClienteService
    {
        Cliente Create(Cliente cliente);
        Cliente FindById(int id);
        List<Cliente> FindAll();
        Cliente Update(Cliente cliente);
        void Delete(int id);

    }
}
