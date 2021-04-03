using RestAPIListaCerta.Models;
using System.Collections.Generic;


namespace RestAPIListaCerta.Services
{
   public interface IListaService
    {
        Lista Create(Lista lista);
        Lista FindById(int id);
        List<Lista> FindAll();
        Lista Update(Lista lista);
        void Delete(int id);

    }
}
