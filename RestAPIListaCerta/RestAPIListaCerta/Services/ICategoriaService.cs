using RestAPIListaCerta.Models;
using System.Collections.Generic;


namespace RestAPIListaCerta.Services
{
   public interface ICategoriaService
    {
        Categoria Create(Categoria categoria);
        Categoria FindById(int id);
        List<Categoria> FindAll();
        Categoria Update(Categoria categoria);
        void Delete(int id);

    }
}
