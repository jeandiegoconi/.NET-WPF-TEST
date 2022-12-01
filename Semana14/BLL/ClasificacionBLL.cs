using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ClasificacionBLL
    {
        ToDoListEntities bd = new ToDoListEntities();

        //CRUD

        public void Add(string nombre)
        {
            Clasificacion nueva = new Clasificacion();
            nueva.Nombre = nombre;

            bd.Clasificacion.Add(nueva);
            bd.SaveChanges();
        }

        public List<Clasificacion> GetAll()
        {

            return bd.Clasificacion.OrderBy(c => c.Nombre).ToList();
        }

        public List<Clasificacion> Filter(string texto)
        {
            return bd.Clasificacion.Where(c => c.Nombre.Contains(texto)).ToList(); 
        }
        

        public void Remove(string nombre)
        {
            //1. Obtener desde la bd el elemento a eliminar
            Clasificacion clasificacion = this.Get(nombre);
            //2. Eliminar el elemento de la bd
            bd.Clasificacion.Remove(clasificacion);

            //3. Guardar los cambios
            bd.SaveChanges();
        }

        public void Update(Clasificacion clasificacion, string nuevoNombre)
        {
            //this.Get(clasificacion.Nombre).Nombre = nuevoNombre;

            //1. Obtener el elemento a modificar en la BD
            Clasificacion c = this.Get(clasificacion.Nombre);
            //2. Realizar los cambios
            c.Nombre = nuevoNombre;
            //3.Guardar los cambios
            bd.SaveChanges();
        }

        public Clasificacion Get(string nombre)
        {
            Clasificacion clasificacion = bd.Clasificacion.Where(c => c.Nombre == nombre).FirstOrDefault();
            return clasificacion;
        }
    }
}
