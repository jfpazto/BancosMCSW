using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.DTO
{
    public class Bancos
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; } 
    }
}
