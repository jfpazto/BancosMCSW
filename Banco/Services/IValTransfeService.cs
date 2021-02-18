using Banco.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.Services
{
    interface IValTransfeService
    {
        TransferenciaVal Actualizar(TransferenciaVal dto);
    }
}
