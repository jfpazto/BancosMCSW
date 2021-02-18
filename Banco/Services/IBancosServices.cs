using ApiRest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Services
{
    public interface IBancosServices
    {
        List<Bancos> Listar();
        Bancos Insert(Bancos dto);

        Bancos Actualizar(Bancos dto);

        Bancos Eliminar(Bancos dto);

        Bancos Recuperar(Bancos dto);
    }
}
