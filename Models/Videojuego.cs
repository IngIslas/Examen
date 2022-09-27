namespace Examen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Videojuego
    {
        public int IdVideojuego { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public int Año { get; set; }

        [Required]
        public double Calificacion { get; set; }

        [Required]
        public string Genero    { get; set; }

        public List<Consola> Consolas { get; set; }
    }
}
