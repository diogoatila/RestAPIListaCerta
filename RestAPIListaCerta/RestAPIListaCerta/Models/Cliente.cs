﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIListaCerta.Models
{
    public class Cliente
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
