using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class InscripcionBLL
    {
        public List<Inscripcion> inscripciones = new List<Inscripcion>();

        public void Agregar(Inscripcion i)
        {
            inscripciones.Add(i);
        }
        public List<Inscripcion> GetAll()
        {
            return inscripciones;
        }
    }
    public class ListaBLL
    {
        public List<Cantidad> Cantidades = new List<Cantidad>();

        public void Agregar(Cantidad i)
        {
            Cantidades.Add(i);
        }
        public List<Cantidad> GetAll()
        {
            return Cantidades;
        }
    }
}
