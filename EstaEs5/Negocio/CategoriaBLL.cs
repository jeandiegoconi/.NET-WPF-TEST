using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class CategoriaBLL
    {
        TareasPendientesEntities tpe = new TareasPendientesEntities();

        public void Add(string nombre)
        {
            Categoria nueva = new Categoria();
            nueva.Nombre = nombre;

            //Acá se podría validar que la categoría no existe antes de agregar

            tpe.Categoria.Add(nueva);
            tpe.SaveChanges();
        }

        public List<Categoria> GetCategorias()
        {
            return tpe.Categoria.ToList();
        }

        public void Delete(string nombre)
        {
            Categoria borrar = this.Find(nombre);
            if (borrar != null)
            {
                tpe.Categoria.Remove(borrar);
                tpe.SaveChanges();
            }
        }
        public void Edit(string nombre, string nuevoNombre)
        {
            Categoria cat = this.Find(nombre);
            cat.Nombre = nuevoNombre;
            tpe.SaveChanges();
            
        }
        public Categoria Find(string nombre)
        {
            return tpe.Categoria.First(c => c.Nombre == nombre);
        }

        
    }
}
