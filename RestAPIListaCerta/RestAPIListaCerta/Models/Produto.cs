using RestAPIListaCerta.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIListaCerta.Models
{
    public class Produto
    {
        public int ProdutoID { get; set; }

        [StringLength (60)]
        public string Nome { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public int MarcaID { get; set; }
        public int CategoriaID { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual Categoria Categoria { get; set; }
        public List<Lista> Listas { get; set; }
        public Status Status { get; set; }



    }
}
