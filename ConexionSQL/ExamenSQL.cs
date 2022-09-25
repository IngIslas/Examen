using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Examen.Models
{
    public class ExamenSQL : DbContext
    {
        public ExamenSQL()
            : base("name=ExamenSQL")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
