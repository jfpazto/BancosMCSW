using ApiRest.Contexto;
using ApiRest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Services
{
    public class MovimientosServicesSQL:IMovimientosServices
    {
        private dbBancos dbBancos;

        public MovimientosServicesSQL(dbBancos dbBancos)
        {
            this.dbBancos = dbBancos;
        }

        public MovimientosTr Actualizar(MovimientosTr dto)
        {
            dbBancos.MovimientosTransacciones.Update(dto);
            dbBancos.SaveChanges();
            return dto;
        }

        public MovimientosTr Eliminar(MovimientosTr dto)
        {
            throw new NotImplementedException();
        }

        public MovimientosTr Insert(MovimientosTr dto)
        {
            dbBancos.MovimientosTransacciones.Add(dto);
            dbBancos.SaveChanges();
            return dto;
        }

        public List<MovimientosTr> Listar()
        {
            return dbBancos.MovimientosTransacciones.ToList();
        }

        public string totMov()
        {
            var query = dbBancos.MovimientosTransacciones.FromSqlRaw($"SELECT count(*) from MovimientosTransacciones ").ToString();
            return query;
        }

        /*public List<MovimientosTr> Recuperar()
        {
            var query = dbBancos.MovimientosTransacciones.FromSqlRaw("select idTransaccion as NumeroTransaccion, MovimientosTransacciones.fecha, MovimientosTransacciones.idEstado,Transaccion.monto as monto from MovimientosTransacciones JOIN Transaccion on Transaccion.id=MovimientosTransacciones.idTransaccion").ToList();
            //string clave = query[0].clave;
            return query;

        }*/
    }
}
