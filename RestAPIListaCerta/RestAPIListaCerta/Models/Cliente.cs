using RestAPIListaCerta.Models.Enums;

namespace RestAPIListaCerta.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Documento { get; set; }
        public Gender Genero { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public StatusCliente StatusCliente { get; set; }
        public Status Status { get; set; }

    }
}
