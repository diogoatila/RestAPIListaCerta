using RestAPIListaCerta.Context;
using RestAPIListaCerta.Models;
using RestAPIListaCerta.Models.Enums;
using RestAPIListaCerta.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestAPIListaCerta.Services.Implementations
{
    public class MarcaService : IMarcaService
    {

     
        private readonly IMarcaRepository _repository;
        public MarcaService(IMarcaRepository repository)
        {
            _repository = repository;
        }

        //Implemente nos métodos abaixo, a regra de negócio da aplicação!

        public List<Marca> FindAll()
        {
            return _repository.FindAll();
        }

        public Marca FindById(int id)
        {
            return _repository.FindById(id);
        }

        public Marca Create(Marca marca)
        {

            return _repository.Create(marca);

        }
        public Marca Update(Marca marca)
        {
            return _repository.Update(marca);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }


    }
}
