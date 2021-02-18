using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.DTO
{
    public class MovimientosTr
    {
        [Key]
        public int id { get; set; }
        

        public DateTime fecha { get; set; }


        public string Estado { get; set; }

        public string mensaje { get; set; }

        public string monto { get; set; }

        public string cuenta { get; set; }

    }
}
