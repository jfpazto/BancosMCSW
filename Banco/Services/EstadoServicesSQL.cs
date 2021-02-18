using ApiRest.Contexto;
using ApiRest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Services
{
    public class EstadoServicesSQL:IEstadoServices
    {
        private dbBancos dbBancos;

        public EstadoServicesSQL(dbBancos dbBancos)
        {
            this.dbBancos = dbBancos;
        }

        public Estado Actualizar(Estado dto)
        {
            
            dbBancos.Estado.Update(dto);
            dbBancos.SaveChanges();
            return dto;
        }

        public int Eliminar(int dto)
        {
            Estado estado=dbBancos.Estado.Find(dto);
            dbBancos.Estado.Remove(estado);
            return dbBancos.SaveChanges();
        }

        public Estado Insert(Estado dto)
        {
            dbBancos.Estado.Add(dto);
            dbBancos.SaveChanges();
            return dto;
        }

        public List<Estado> Listar()
        {
            

            return dbBancos.Estado.ToList();
        }

        public Estado Recuperar(int dto)
        {
            Estado estado = dbBancos.Estado.Find(dto);
            Console.WriteLine(estado.nombre);
            
            return estado;
        }
    }
}
