using RestAPIListaCerta.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestAPIListaCerta.Models
{
    public class Marca
    {
        public int MarcaID { get; set; }

        [StringLength (60)]
        public string Nome { get; set; }
        public List<Categoria> Categorias { get; set; }
        public List<Produto> Produtos { get; set; }
        public Status Status { get; set; }

    }
}
