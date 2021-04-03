using RestAPIListaCerta.Models;
using System.Collections.Generic;


namespace RestAPIListaCerta.Repository
{
   public interface IListaRepository
    {
        Lista Create(Lista cliente);
        Lista FindById(int id);
        List<Lista> FindAll();
        Lista Update(Lista cliente);
        void Delete(int id);
        bool Exists(int id);
 
    }
}
