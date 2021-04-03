using RestAPIListaCerta.Models;
using System.Collections.Generic;


namespace RestAPIListaCerta.Repository
{
   public interface ICategoriaRepository
    {
        Categoria Create(Categoria categoria);
        Categoria FindById(int id);
        List<Categoria> FindAll();
        Categoria Update(Categoria categoria);
        void Delete(int id);
        bool Exists(int id);
 
    }
}
