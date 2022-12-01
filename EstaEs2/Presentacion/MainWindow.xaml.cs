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
using Datos;
using Negocio;

namespace Presentacion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SuscripcionBLL sbll = new SuscripcionBLL();

        public MainWindow()
        {
            InitializeComponent();
            CboClasificacion.ItemsSource = Enum.GetValues(typeof(Tipo));
            CboClasificacion.SelectedIndex = 3;
        }

        private void BtnSaludar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = TxtNombre.Text;
            if (string.IsNullOrEmpty(nombre))
            {
                LblSaludo.Content = "Hola Mundo";
            }
            else
            {
                LblSaludo.Content = "Hola "+ nombre;
            }

        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Suscripcion nueva = new Suscripcion();
            nueva.Nombre = TxtNombreSuscripcion.Text.Trim();
            nueva.MontoMensual = int.Parse(TxtMonto.Text);
            nueva.Clasificacion =(Tipo) CboClasificacion.SelectedValue;
            nueva.FechaInicio = (DateTime)DpFechaInicio.SelectedDate;

            //Validación del formulario

            sbll.Add(nueva);

            LstSuscripciones.ItemsSource = null;
            LstSuscripciones.ItemsSource = sbll.GetAll();


        }
    }
}
