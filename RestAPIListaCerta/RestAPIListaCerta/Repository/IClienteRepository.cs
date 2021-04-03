using RestAPIListaCerta.Models;
using System.Collections.Generic;


namespace RestAPIListaCerta.Repository
{
   public interface IClienteRepository
    {
        Cliente Create(Cliente cliente);
        Cliente FindById(int id);
        List<Cliente> FindAll();
        Cliente Update(Cliente cliente);
        void Delete(int id);
        bool Exists(int id);
 
    }
}
