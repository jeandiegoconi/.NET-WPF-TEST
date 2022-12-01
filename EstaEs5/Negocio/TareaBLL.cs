using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class TareaBLL
    {
        TareasPendientesEntities tpe = new TareasPendientesEntities();

      

        public void Add(string titulo, string cuerpo, Nullable<DateTime> fechaVencimiento , string estado, Categoria categoria)
        {
            Tarea nueva = new Tarea();
            nueva.Titulo = titulo;
            nueva.Cuerpo = cuerpo;
            nueva.FechaCreacion = DateTime.Today;
            nueva.FechaVencimiento = fechaVencimiento;
            nueva.Estado = estado;
            nueva.IdCategoria = categoria.Id;

            tpe.Tarea.Add(nueva);
            tpe.SaveChanges();
        }

        public List<Tarea> GetTareas()
        {
            return tpe.Tarea.ToList();
        }

        public List<Tarea> GetTareasPorEstado(string estado)
        {
            return tpe.Tarea.Where(t => t.Estado == estado).ToList();
        }
    }
}
