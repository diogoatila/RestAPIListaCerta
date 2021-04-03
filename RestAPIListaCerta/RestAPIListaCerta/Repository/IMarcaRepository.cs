using RestAPIListaCerta.Models;
using System.Collections.Generic;


namespace RestAPIListaCerta.Repository
{
   public interface IMarcaRepository
    {
        Marca Create(Marca marca);
        Marca FindById(int id);
        List<Marca> FindAll();
        Marca Update(Marca marca);
        void Delete(int id);
        bool Exists(int id);
 
    }
}
