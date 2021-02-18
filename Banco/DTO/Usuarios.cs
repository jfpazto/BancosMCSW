using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.DTO
{
    public class Usuarios
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }

        public string apellido { get; set; }

        public string saldo { get; set; }

        public DateTime fecha { get; set; }

        public string cuenta { get; set; }

        public string clave { get; set; }

        public string rol { get; set; }

        public string cedula { get; set; }
    }
}
