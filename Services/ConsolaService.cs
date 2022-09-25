using Examen.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Examen.Services
{
    public class ConsolaService
    {

        public static DbRawSqlQuery<Consola> ObtenerConsolas(int IdVideojuego=0)
        {
            ExamenSQL sql = new ExamenSQL();
            SqlParameter OpcionParameter = new SqlParameter("@Opcion",IdVideojuego==0? 4:2);
            SqlParameter IdVideojuegoParameter = new SqlParameter("@IdVideojuego", IdVideojuego);
            return sql.Database.SqlQuery<Consola>("SpAccionesVideojuegos @Opcion, @IdVideojuego", OpcionParameter, IdVideojuegoParameter);
        }
        public static bool InsertarConsola(Consola consola)
        {
            ExamenSQL SQL = new ExamenSQL();
            SqlParameter OpcionParameter = new SqlParameter("@Opcion", 5);
            SqlParameter ConsolaParameter = new SqlParameter("@Consola", consola.Nombre);
            DbCommand command = SQL.Database.Connection.CreateCommand();
            SQL.Database.Connection.Open();
            command.CommandText = "SpAccionesVideojuegos";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(OpcionParameter);
            command.Parameters.Add(ConsolaParameter);
            var i = command.ExecuteNonQuery();
            return i > 0 ? true : false;
        }
    }
}