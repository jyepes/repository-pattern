using System;
using System.Collections.Generic;

namespace Entities.Domain
{
    public class Artista
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public IEnumerable<Album> Albumes { get; set; }
    }
}
