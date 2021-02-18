using ApiRest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Services
{
    public interface IUsuariosServices
    {
        List<Usuarios> Imprime();
        List<Usuarios> Listar(string dto);
        List<Usuarios> LCuenta(string dto);
        Usuarios Insert(Usuarios dto);

        Usuarios Actualizar(Usuarios dto);

        Usuarios Eliminar(Usuarios dto);

        Usuarios Recuperar(Usuarios dto);

        String Login(string dto);

        String Roles(string dto);
    }
}
