using RestAPIListaCerta.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestAPIListaCerta.Models
{
    public class Categoria
    {
        public int CategoriaID { get; set; }

        [StringLength (100)]
        public string Descricao { get; set; }
        public List<Produto> Produtos { get; set; }
        public List<Marca> Marca { get; set; }
        public Status Status { get; set; }

    }
}
