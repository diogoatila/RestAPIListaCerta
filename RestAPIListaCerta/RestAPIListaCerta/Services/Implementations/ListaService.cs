using RestAPIListaCerta.Context;
using RestAPIListaCerta.Models;
using RestAPIListaCerta.Models.Enums;
using RestAPIListaCerta.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestAPIListaCerta.Services.Implementations
{
    public class ListaService : IListaService
    {

     
        private readonly IListaRepository _repository;
        public ListaService(IListaRepository repository)
        {
            _repository = repository;
        }

        //Implemente nos métodos abaixo, a regra de negócio da aplicação!

        public List<Lista> FindAll()
        {
            return _repository.FindAll();
        }

        public Lista FindById(int id)
        {
            return _repository.FindById(id);
        }

        public Lista Create(Lista lista)
        {

            return _repository.Create(lista);

        }
        public Lista Update(Lista lista)
        {
            return _repository.Update(lista);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }


    }
}
