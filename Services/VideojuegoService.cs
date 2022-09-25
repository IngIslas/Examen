using Antlr.Runtime.Tree;
using Examen.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;

namespace Examen.Services
{
    public class VideojuegoService
    {

        public static DbRawSqlQuery<Videojuego> Obtener()
        {
            ExamenSQL SQl = new ExamenSQL();
            SqlParameter OpcionParameter = new SqlParameter("@Opcion", 1);
            return SQl.Database.SqlQuery<Videojuego>("SpAccionesVideojuegos @Opcion", OpcionParameter);

        }

         public static DbRawSqlQuery<Videojuego> Insertar(Videojuego videojuego)
        {
            ExamenSQL SQL = new ExamenSQL();
            SqlParameter OpcionParameter = new SqlParameter("@Opcion", 3);
            SqlParameter IdVideojuegoParameter = new SqlParameter("@IdVideojuego", DBNull.Value);
            SqlParameter TituloParameter = new SqlParameter("@Titulo", videojuego.Titulo);
            SqlParameter DescripcionParameter = new SqlParameter("@Descripcion", videojuego.Descripcion);
            SqlParameter AnioParameter = new SqlParameter("@Año", videojuego.Anio);
            SqlParameter CalificacionParameter = new SqlParameter("@Calificacion", videojuego.Calificacion);
            SqlParameter GeneroParameter = new SqlParameter("@Genero", videojuego.Genero);

            return SQL.Database.SqlQuery<Videojuego>("SpAccionesVideojuegos @Opcion, @IdVideojuego, @Titulo, @Descripcion, @Año, @Calificacion, @Genero",
                OpcionParameter, IdVideojuegoParameter, TituloParameter, DescripcionParameter, AnioParameter, CalificacionParameter, GeneroParameter);
        }
      
        public static void AsignarConsola(int idVideojuego, Consola consola)
        {
            ExamenSQL SQL = new ExamenSQL();
            SqlParameter OpcionParameter = new SqlParameter("@Opcion", 6);
            SqlParameter IdVideojuegoParameter = new SqlParameter("@IdVideojuego", idVideojuego);
            SqlParameter IdConsolaParameter = new SqlParameter("@IdConsola", consola.IdConsola);
            DbCommand command = SQL.Database.Connection.CreateCommand();
            SQL.Database.Connection.Open();
            command.CommandText = "SpAccionesVideojuegos";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(OpcionParameter);
            command.Parameters.Add(IdVideojuegoParameter);
            command.Parameters.Add(IdConsolaParameter);
            var i = command.ExecuteNonQuery();
        }

        public static void DesasignarConsolas(int idVideojuego) {
            ExamenSQL SQL = new ExamenSQL();
            SqlParameter OpcionParameter = new SqlParameter("@Opcion", 7);
            SqlParameter IdVideojuegoParameter = new SqlParameter("@IdVideojuego", idVideojuego);
            DbCommand command = SQL.Database.Connection.CreateCommand();
            SQL.Database.Connection.Open();
            command.CommandText = "SpAccionesVideojuegos";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(OpcionParameter);
            command.Parameters.Add(IdVideojuegoParameter);
            var i = command.ExecuteNonQuery();
        }

        public static DbRawSqlQuery<Videojuego> Actualizar(Videojuego videojuego) {
            ExamenSQL SQL = new ExamenSQL();
            SqlParameter OpcionParameter = new SqlParameter("@Opcion", 8);
            SqlParameter IdVideojuegoParameter = new SqlParameter("@IdVideojuego", videojuego.IdVideojuego);
            SqlParameter TituloParameter = new SqlParameter("@Titulo", videojuego.Titulo);
            SqlParameter DescripcionParameter = new SqlParameter("@Descripcion", videojuego.Descripcion);
            SqlParameter AnioParameter = new SqlParameter("@Año", videojuego.Anio);
            SqlParameter CalificacionParameter = new SqlParameter("@Calificacion", videojuego.Calificacion);
            SqlParameter GeneroParameter = new SqlParameter("@Genero", videojuego.Genero);

            return SQL.Database.SqlQuery<Videojuego>("SpAccionesVideojuegos @Opcion, @IdVideojuego, @Titulo, @Descripcion, @Año, @Calificacion, @Genero",
                OpcionParameter, IdVideojuegoParameter, TituloParameter, DescripcionParameter, AnioParameter, CalificacionParameter, GeneroParameter);

        }

        public static DbRawSqlQuery<Videojuego> Eliminar(Videojuego videojuego)
        {
            ExamenSQL SQL = new ExamenSQL();
            SqlParameter OpcionParameter = new SqlParameter("@Opcion", 9);
            SqlParameter IdVideojuegoParameter = new SqlParameter("@IdVideojuego", videojuego.IdVideojuego);
            //SqlParameter TituloParameter = new SqlParameter("@Titulo", videojuego.Titulo);
            //SqlParameter DescripcionParameter = new SqlParameter("@Descripcion", videojuego.Descripcion);
            //SqlParameter AnioParameter = new SqlParameter("@Año", videojuego.Anio);
            //SqlParameter CalificacionParameter = new SqlParameter("@Calificacion", videojuego.Calificacion);
            //SqlParameter GeneroParameter = new SqlParameter("@Genero", videojuego.Genero);

            return SQL.Database.SqlQuery<Videojuego>("SpAccionesVideojuegos @Opcion, @IdVideojuego",OpcionParameter, IdVideojuegoParameter);

            //return SQL.Database.SqlQuery<Videojuego>("SpAccionesVideojuegos @Opcion, @IdVideojuego, @Titulo, @Descripcion, @Año, @Calificacion, @Genero",
            //    OpcionParameter, IdVideojuegoParameter, TituloParameter, DescripcionParameter, AnioParameter, CalificacionParameter, GeneroParameter);

        }
    }
}