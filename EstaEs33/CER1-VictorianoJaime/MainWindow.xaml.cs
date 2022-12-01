using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL;
using Data;

namespace CER1_VictorianoJaime
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ListaInscripciones li = new ListaInscripciones();
        int total = 0;
        public MainWindow()
        {
            InitializeComponent();
            cmbPelicula.ItemsSource = Enum.GetValues(typeof(Pelicula));
            cmbJornada.ItemsSource = Enum.GetValues(typeof(Jornada));
            cmbPelicula.SelectedIndex = 0;
            cmbJornada.SelectedIndex = 0;
            refrescar();
        }

        private void refrescar()
        {
            lblEntradas.Content = "Cantidad Total de Entradas: " + total;
            foreach (string pelicula in Enum.GetNames(typeof(Pelicula)))
            {
                lblEntradas.Content += "\n" + pelicula + ":";
                foreach (string jornada in Enum.GetNames(typeof(Jornada)))
                {
                    lblEntradas.Content += "\n\t" + jornada + ": " + li.GetCount(pelicula, jornada);
                }
            }
                //"\nMatrix:\n\tMatiné: " + li.GetCount("Matrix", "Matiné");
            lstInscripcion.Items.Clear();
            foreach (Inscripcion inscripcion in li.GetAll())
            {
                lstInscripcion.Items.Add(inscripcion.Nombre);
            }
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            bool valido = int.TryParse(txtCantidad.Text.Trim(), out int entradas);
            if (valido && entradas > 0 && entradas < 6 && txtNombre.Text.Trim() != "" && txtTelefono.Text.Trim() != "")
            {
                //
                Console.WriteLine("Si.");
                //
                Inscripcion nueva = new Inscripcion();
                nueva.Pelicula = cmbPelicula.SelectedItem.ToString();
                nueva.Jornada = cmbJornada.SelectedItem.ToString();
                nueva.Entradas = entradas;
                nueva.Adquisicion = DateTime.Today;
                nueva.Nombre = txtNombre.Text.Trim();
                nueva.Telefono = txtTelefono.Text.Trim();
                li.Add(nueva);

                total += nueva.Entradas;
                refrescar();
                //
                Console.WriteLine(nueva.Pelicula);
                //
            }
            //
            else
            {
                Console.WriteLine("No.");
            }
            //
        }

        private void LstInscripcion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Inscripcion i = li.GetInscripcion(lstInscripcion.SelectedItem.ToString());
            lblInscripcion.Content = "Pelicula: " + i.Pelicula + "\nCantidad: " + i.Entradas + "\nNombre: " + i.Nombre + "\nTelefono: " + i.Telefono;
        }
    }
}
