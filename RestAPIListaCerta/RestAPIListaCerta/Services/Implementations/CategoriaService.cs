using RestAPIListaCerta.Context;
using RestAPIListaCerta.Models;
using RestAPIListaCerta.Models.Enums;
using RestAPIListaCerta.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestAPIListaCerta.Services.Implementations
{
    public class CategoriaService : ICategoriaService
    {

     
        private readonly ICategoriaRepository _repository;
        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        //Implemente nos métodos abaixo, a regra de negócio da aplicação!

        public List<Categoria> FindAll()
        {
            return _repository.FindAll();
        }

        public Categoria FindById(int id)
        {
            return _repository.FindById(id);
        }

        public Categoria Create(Categoria categoria)
        {

            return _repository.Create(categoria);

        }
        public Categoria Update(Categoria categoria)
        {
            return _repository.Update(categoria);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }


    }
}
