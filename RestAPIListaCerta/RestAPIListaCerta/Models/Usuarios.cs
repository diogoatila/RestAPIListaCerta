using RestAPIListaCerta.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIListaCerta.Models
{
    public class Usuarios
    {
        public int ID { get; set; }

        [StringLength (50)]
        public string UserName { get; set; }

        public string Email { get; set; }
        public StatusCliente StatusCliente { get; set; }

        [StringLength (130)]
        public string Password { get; set; }

        [StringLength (130)]
        public string NomeCompleto { get; set; }
        public string  RefreshToken { get; set; }
        public DateTime ExpiryTime { get; set; }
        
    }
}
