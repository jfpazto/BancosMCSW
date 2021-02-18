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

            var query = dbBancos.Usuarios.FromSqlRaw($"SELECT * from Usuarios where cedula='{dto}'").ToList();
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
            var query = dbBancos.Usuarios.FromSqlRaw($"SELECT * from Usuarios where cuenta='{dto}'").ToList();
            string clave = query[0].clave;

            return query;

        }

        public Usuarios Recuperar(Usuarios dto)
        {
            throw new NotImplementedException();
        }

        public String Login(string dto)
        {
            var query = dbBancos.Usuarios.FromSqlRaw($"SELECT * from Usuarios where cedula='{dto}'").ToList();
            string clave = query[0].clave;
            return clave;

        }

        public String Roles(string dto)
        {
            var query = dbBancos.Usuarios.FromSqlRaw($"SELECT * from Usuarios where cedula='{dto}'").ToList();
            string clave = query[0].rol;
            return clave;

        }

    }
}
