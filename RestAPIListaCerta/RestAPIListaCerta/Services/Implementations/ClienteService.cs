using RestAPIListaCerta.Context;
using RestAPIListaCerta.Models;
using RestAPIListaCerta.Models.Enums;
using RestAPIListaCerta.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestAPIListaCerta.Services.Implementations
{
    public class ClienteService : IClienteService
    {

     
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        //Implemente nos métodos abaixo, a regra de negócio da aplicação!

        public List<Cliente> FindAll()
        {
            return _repository.FindAll();
        }

        public Cliente FindById(int id)
        {
            return _repository.FindById(id);
        }

        public Cliente Create(Cliente cliente)
        {

            return _repository.Create(cliente);

        }
        public Cliente Update(Cliente cliente)
        {
            return _repository.Update(cliente);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }


    }
}
