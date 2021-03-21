using RestAPIListaCerta.Models;
using System.Collections.Generic;

namespace RestAPIListaCerta.Services
{
    public interface IProdutoService
    {
        Produto Create(Produto produto);
        Produto FindById(int id);
        List<Produto> FindAll();
        Produto Update(Produto produto);
        void Delete(int id);
    }
}
