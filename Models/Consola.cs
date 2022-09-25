namespace Examen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Consola
    {
        public int IdConsola { get; set; }
        public string Nombre { get; set; }

    }
}
