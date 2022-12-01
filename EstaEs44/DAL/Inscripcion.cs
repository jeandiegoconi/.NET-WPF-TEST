using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Inscripcion
    {
        public Pelicula Pelicula { get; set; }
        public Jornada Jornada { get; set; }
        public int CantidadEntradas { get; set; }
        public DateTime FechaAdquisicion { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public override string ToString()
        {
            return "Pelicula: " + this.Pelicula + 
                "\nCantidad de entradas: " + this.CantidadEntradas + 
                "\nNombre: " + this.Nombre + 
                "\nTelefono: " + this.Telefono;
        }
    }
    public class Cantidad
    {
        public int MatrixMatine { get; set; }
        public int MatrixTarde { get; set; }
        public int MatrixTrasnoche { get; set; }
        public int TimelessMatine { get; set; }
        public int TimelessTarde { get; set; }
        public int TimelessTrasnoche { get; set; }
        public int FrozenMatine { get; set; }
        public int FrozenTarde { get; set; }
        public int FrozenTrasnoche { get; set; }

        public override string ToString()
        {
            return "Total de entradas por jornada" +
                "\nMatrix: " + "\n Matine: " + this.MatrixMatine + " Tarde: " + this.MatrixTarde + " Trasnoche: " + this.MatrixTrasnoche +
                "\nTimeless: " + "\n Matine: " + this.TimelessMatine + " Tarde: " + this.TimelessTarde + " Trasnoche: " + this.TimelessTrasnoche +
                "\nFrozen: " + "\n Matine: " + this.FrozenMatine + " Tarde: " + this.FrozenTarde + " Trasnoche: " + this.FrozenTrasnoche + "\n";
        }
    }
}
