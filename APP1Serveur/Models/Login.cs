﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP1Serveur.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public List<Answers> Responses { get; set; }
    }
}
