using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ListaInscripciones
    {
        List<Inscripcion> listaInscripciones = new List<Inscripcion>();

        public void Add(Inscripcion nueva)
        {
            listaInscripciones.Add(nueva);
        }

        public List<Inscripcion> GetAll()
        {
            return listaInscripciones;
        }

        public Inscripcion GetInscripcion(string nombre)
        {
            return listaInscripciones.Find(i => i.Nombre.Equals(nombre));
        }

        public int GetCount(string pelicula, string jornada)
        {
            return listaInscripciones.FindAll(i => i.Pelicula.Equals(pelicula) && i.Jornada.Equals(jornada)).Sum(x => x.Entradas);
        }
    }
}
