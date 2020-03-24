using System;
namespace Entities.Domain
{

    public class Album
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ArtistaId { get; set; }
        public Artista Artistas { get; set; }
    }
}
