using RestAPIListaCerta.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPIListaCerta.Models
{
    public class Lista
    {
        public int ListaID { get; set; }
        public int QuantidadeProduto { get; set; }

        [StringLength (60)]
        public string NomeProduto { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorProduto { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorTotal { get; set; }
        public int ClienteID { get; set; }
        public List<Produto> Produtos { get; set; }
        public virtual Cliente Cliente { get; set; }
        public Status Status { get; set; }


    }
}
