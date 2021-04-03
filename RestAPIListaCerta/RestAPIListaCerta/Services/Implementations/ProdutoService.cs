using RestAPIListaCerta.Context;
using RestAPIListaCerta.Models;
using RestAPIListaCerta.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace RestAPIListaCerta.Services.Implementations
{
    public class ProdutoService : IProdutoService
    {

      

        private readonly IProdutoRepository _repository;
        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        //Implemente nos métodos abaixo, a regra de negócio da aplicação!

        public List<Produto> FindAll()
        {
            return _repository.FindAll();
        }

        public Produto FindById(int id)
        {
            return _repository.FindByID(id);
        }
        public Produto Create(Produto produto)
        {
            return _repository.Create(produto);
        }
        public Produto Update(Produto produto)
        {
            return _repository.Update(produto);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

    }
}
