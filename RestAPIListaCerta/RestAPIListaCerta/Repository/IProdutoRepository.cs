using RestAPIListaCerta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIListaCerta.Repository
{
    public interface IProdutoRepository
    {
        Produto Create(Produto produto);
        Produto FindByID(int id);
        List<Produto> FindAll();
        Produto Update(Produto produto);
        void Delete(int id);
        bool Exists(int id);
    }
}
