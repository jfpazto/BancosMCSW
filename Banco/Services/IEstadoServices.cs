using ApiRest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Services
{
    public interface IEstadoServices
    {
        List<Estado> Listar();
        Estado Insert(Estado dto);

        Estado Actualizar(Estado dto);

        int Eliminar(int dto);

        Estado Recuperar(int dto);
    }
}
