using System;

namespace G2S1.BlazorServer.Data
{
    public class Book
    {
        //[Key]
        public Guid? BookId { get; set; }

        //[Range(1, long.MaxValue, ErrorMessage = "Autor es requerido")]
        public Guid AuthorId { get; set; }

        public Guid GenderId { get; set; }

        //[Required(ErrorMessage = "Nombre es requerido")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Fecha Publicación es requerido")]
        public DateTime? PublishDate { get; set; }

        //[Required(ErrorMessage = "Precio es requerido")]
        public double Price { get; set; }

        //[Required(ErrorMessage = "Páginas es requerido")]
        public int Pages { get; set; }

        //[Required(ErrorMessage = "Estado es requerido")]
        public bool State { get; set; }
    }
}
