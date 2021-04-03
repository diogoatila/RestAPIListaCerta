using RestAPIListaCerta.Models;
using System.Collections.Generic;


namespace RestAPIListaCerta.Services
{
   public interface IMarcaService
    {
        Marca Create(Marca marca);
        Marca FindById(int id);
        List<Marca> FindAll();
        Marca Update(Marca cliente);
        void Delete(int id);

    }
}
