﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class PeliculasDTO
    {
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string Trailer { get; set; }
        public string Poster { get; set; }
        public int GeneroId { get; set; }
     
    }
}
