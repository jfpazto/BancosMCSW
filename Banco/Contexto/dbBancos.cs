using ApiRest.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Contexto
{
    public class dbBancos: DbContext
    {
        public dbBancos(DbContextOptions<dbBancos> dbContextOptions):base(dbContextOptions)
        {

        }
        public DbSet<Bancos> Bancos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Estado> Estado { get; set; }


        public DbSet<MovimientosTr> MovimientosTransacciones { get; set; }



        

    }
}
