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
using DAL;

namespace PL
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClasificacionBLL cbll = new ClasificacionBLL();
        Clasificacion clasificacion = new Clasificacion();
        public MainWindow()
        {
            InitializeComponent();
            lstClasificaciones.ItemsSource = cbll.GetAll();
        }

        private void BtnNuevaClasificacion_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtClasificacion.Text;

            //Validaciones de entrada

            cbll.Add(nombre);

            MessageBox.Show("Clasificación creada", "Nueva Clasificacion", MessageBoxButton.OK, MessageBoxImage.Information);
            txtClasificacion.Text = string.Empty;

            lstClasificaciones.ItemsSource = null;
            lstClasificaciones.ItemsSource = cbll.GetAll();

        }

        private void BtnEliminarClasificacion_Click(object sender, RoutedEventArgs e)
        {
            string nombre = lstClasificaciones.SelectedValue.ToString();
            cbll.Remove(nombre);

            lstClasificaciones.ItemsSource = null;
            lstClasificaciones.ItemsSource = cbll.GetAll();

        }

        private void BtnEditarClasificacion_Click(object sender, RoutedEventArgs e)
        {
            btnNuevaClasificacion.Visibility = Visibility.Hidden;
            btnCancelarEdicion.Visibility = Visibility.Visible;
            btnGuardarClasificacion.Visibility = Visibility.Visible;

            clasificacion = (Clasificacion)lstClasificaciones.SelectedItem;
            //(RECORDAR VALIDAR QUE HAYA UN ELEMENTO SELECCIONADO)

            txtClasificacion.Text = clasificacion.Nombre;


        }

        private void BtnCancelarEdicion_Click(object sender, RoutedEventArgs e)
        {
            btnNuevaClasificacion.Visibility = Visibility.Visible;
            btnCancelarEdicion.Visibility = Visibility.Hidden;
            btnGuardarClasificacion.Visibility = Visibility.Hidden;

            txtClasificacion.Text = string.Empty;
        }

        private void BtnGuardarClasificacion_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtClasificacion.Text.Trim();
            cbll.Update(clasificacion, nombre);

            lstClasificaciones.ItemsSource = null;
            lstClasificaciones.ItemsSource = cbll.GetAll();

            txtClasificacion.Text = string.Empty;

            btnNuevaClasificacion.Visibility = Visibility.Visible;
            btnCancelarEdicion.Visibility = Visibility.Hidden;
            btnGuardarClasificacion.Visibility = Visibility.Hidden;


        }

        private void BtnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            string texto = txtFiltro.Text;
            //VALIDACIONES

            lstClasificaciones.ItemsSource = null;
            lstClasificaciones.ItemsSource = cbll.Filter(texto);
        }
    }
}
