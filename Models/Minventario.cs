using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace P_Inventario.Models
{
    public class Minventario
    {
        public int id { get; set; }
        public string nombre_producto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
    }
}
