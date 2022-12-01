using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Suscripcion
    {
        public string Nombre { get; set; }
        public int MontoMensual { get; set; }
        public Tipo Clasificacion { get; set; }
        public DateTime FechaInicio { get; set; }

        public override string ToString()
        {
            return this.Nombre + " $" + this.MontoMensual; 
        }

    }
}
