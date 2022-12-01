using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class SuscripcionBLL
    {
        List<Suscripcion> suscripciones = new List<Suscripcion>();

        //CRUD
        public void Add(Suscripcion suscripcion)
        {
            //VALIDACION
            suscripciones.Add(suscripcion);
        }

        public List<Suscripcion> GetAll()
        {
            return suscripciones;
        }
    }
}
