using ApiRest.Contexto;
using ApiRest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Services
{
    public class BancosServicesSQL: IBancosServices
    {
        private dbBancos dbBancos;

        public BancosServicesSQL(dbBancos dbBancos)
        {
            this.dbBancos = dbBancos;
        }

        public Bancos Actualizar(Bancos dto)
        {
            dbBancos.Bancos.Update(dto);
            dbBancos.SaveChanges();
            return dto;
        }

        public Bancos Eliminar(Bancos dto)
        {
            throw new NotImplementedException();
        }

        public Bancos Insert(Bancos dto)
        {
            dbBancos.Bancos.Add(dto);
            dbBancos.SaveChanges();
            return dto;
        }

        public List<Bancos> Listar()
        {
            return dbBancos.Bancos.ToList();
        }

        public Bancos Recuperar(Bancos dto)
        {
            throw new NotImplementedException();
        }
    }
}
