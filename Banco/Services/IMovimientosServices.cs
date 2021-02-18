using ApiRest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Services
{
    public interface IMovimientosServices
    {
        List<MovimientosTr> Listar();
        String totMov();
        MovimientosTr Insert(MovimientosTr dto);

        MovimientosTr Actualizar(MovimientosTr dto);

        MovimientosTr Eliminar(MovimientosTr dto);

        /*MovimientosTr Recuperar();*/
    }
}
