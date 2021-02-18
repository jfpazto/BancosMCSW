using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoEscritorio
{
    public class Movimientos
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public string estado { get; set; }

        public string mensaje { get; set; }

        public string monto { get; set; }

        public string cuenta { get; set; }
    }
}
