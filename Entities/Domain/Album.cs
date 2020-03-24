using System;
namespace Entities.Domain
{

    public class Album
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Artista Artista { get; set; }
    }
}
