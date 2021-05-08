using ApiRest.Contexto;
using ApiRest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Services
{
    public class UsuariosServicesSQL:IUsuariosServices
    {
        private dbBancos dbBancos;

        public UsuariosServicesSQL(dbBancos dbBancos)
        {
            this.dbBancos = dbBancos;
        }

        public Usuarios Actualizar(Usuarios dto)
        {
            dbBancos.Usuarios.Update(dto);
            dbBancos.SaveChanges();
            return dto;
        }

        public Usuarios Eliminar(Usuarios dto)
        {
            throw new NotImplementedException();
        }

        public Usuarios Insert(Usuarios dto)
        {
            dbBancos.Usuarios.Add(dto);
            dbBancos.SaveChanges();
            return dto;
        }

        public List<Usuarios> Listar(string dto)
        {
            
            //var query = dbBancos.Usuarios.FromSqlRaw($"SELECT * from Usuarios where cedula='{dto}'").ToList();
            var connstring = ConfigurationManager.ConnectionStrings["connectionSqlInjection"].ConnectionString;
            var query = @"SELECT * FROM Usuarios WHERE cedula = @dto";
            //si no sirve así entonces con dbBancos (En la línea que sigue la de abajo :v) que es la variable de conexión entiendo yo
            using (SqlConnection sql = new SqlConnection(connstring)) 
            {
                sql.Open();
                using(SqlCommand cmd = new SqlCommand(query, sql))
                {
                    cmd.Parameters.Add(new SqlParameter("@dto", dto));
                    var dt = new DataTable();
                    var da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                Console.Read();
                sql.Close();
            }
            /*
            -----------------------------------------------------------------------
            Otra forma sería esta sin el connstring
            SqlConnection sql = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand(query, sql);
            cmd.Parameters.AddWithValue("@dto", sql);
            sql.Open();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            sql.Close();
            Hasta acá
            */
            /*SqlCommand query = new SqlCommand("SELECT * from Usuarios where cedula=@dto");
            query.Parameters.Add("@dto", SqlDbType.VarChar, 32).Value = dto;
            dbBancos.Usuarios.FromSqlRaw(query);*/
            string clave = query[0].clave;
            
                  
            return query;

        }
        public List<Usuarios> Imprime()
        {
            var query = dbBancos.Usuarios.ToList();
            string clave = query[0].clave;

            return query;

        }
        public List<Usuarios> LCuenta(string dto)
        {
            //var query = dbBancos.Usuarios.FromSqlRaw($"SELECT * from Usuarios where cuenta='{dto}'").ToList();
            var connstring = ConfigurationManager.ConnectionStrings["connectionSqlInjection"].ConnectionString;
            var query = @"SELECT * FROM Usuarios WHERE cedula = @dto";
            using (SqlConnection sql = new SqlConnection(connstring))
            {
                sql.Open();
                using(SqlCommand cmd = new SqlCommand(query, sql))
                {
                    cmd.Parameters.Add(new SqlParameter("@dto", dto));
                    var dt = new DataTable();
                    var da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                Console.Read();
                sql.Close();
            }
            /*SqlCommand query = new SqlCommand("SELECT * from Usuarios where cuenta=@dto");
            query.Parameters.Add("@dto", SqlDbType.VarChar, 32).Value = dto;
            dbBancos.Usuarios.FromSqlRaw(query);
            string clave = query[0].clave;

            return query;*/

        }

        public Usuarios Recuperar(Usuarios dto)
        {
            throw new NotImplementedException();
        }

        public String Login(string dto)
        {
            //var query = dbBancos.Usuarios.FromSqlRaw($"SELECT * from Usuarios where cedula='{dto}'").ToList();
            var connstring = ConfigurationManager.ConnectionStrings["connectionSqlInjection"].ConnectionString;
            var query = @"SELECT * FROM Usuarios WHERE cedula = @dto";
            using (SqlConnection sql = new SqlConnection(connstring))
            {
                sql.Open();
                using(SqlCommand cmd = new SqlCommand(query, sql))
                {
                    cmd.Parameters.Add(new SqlParameter("@dto", dto));
                    var dt = new DataTable();
                    var da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                Console.Read();
                sql.Close();
            }
            /*SqlCommand query = new SqlCommand("SELECT * from Usuarios where cedula=@dto");
            query.Parameters.Add("@dto", SqlDbType.VarChar, 32).Value = dto;
            dbBancos.Usuarios.FromSqlRaw(query);
            string clave = query[0].clave;
            return clave;*/

        }

        public String Roles(string dto)
        {
            //var query = dbBancos.Usuarios.FromSqlRaw($"SELECT * from Usuarios where cedula='{dto}'").ToList();
            var connstring = ConfigurationManager.ConnectionStrings["connectionSqlInjection"].ConnectionString;
            var query = @"SELECT * FROM Usuarios WHERE cedula = @dto";
            using (SqlConnection sql = new SqlConnection(connstring))
            {
                sql.Open();
                using(SqlCommand cmd = new SqlCommand(query, sql))
                {
                    cmd.Parameters.Add(new SqlParameter("@dto", dto));
                    var dt = new DataTable();
                    var da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                Console.Read();
                sql.Close();
            }
            /*SqlCommand query = new SqlCommand("SELECT * from Usuarios where cedula=@dto");
            query.Parameters.Add("@dto", SqlDbType.VarChar, 32).Value = dto;
            dbBancos.Usuarios.FromSqlRaw(query);
            string clave = query[0].rol;
            return clave;*/

        }

    }
}
