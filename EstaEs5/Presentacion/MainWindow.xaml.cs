using Datos;
using Negocio;
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

namespace Presentacion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CategoriaBLL cbll = new CategoriaBLL();
        TareaBLL tbll = new TareaBLL();
        Categoria catEditar;
        public MainWindow()
        {
            InitializeComponent();

            CargarCategorias();
            CargarTareas();

            cboEstado.ItemsSource = Enum.GetValues(typeof(Estado));
            cboEstado.SelectedIndex = 0;

            cboFiltroEstado.ItemsSource = Enum.GetValues(typeof(Estado));
            //cboFiltroEstado.Items.Insert(0,"Todos");
            cboFiltroEstado.SelectedIndex = 0;

            cboCategoria.ItemsSource = cbll.GetCategorias();
            cboCategoria.SelectedIndex = 0;

        }

        private void CargarTareas()
        {
            dgTareas.ItemsSource = tbll.GetTareas();
        }

        private void CargarCategorias()
        {
            lstCategorias.ItemsSource = null;
            lstCategorias.ItemsSource = cbll.GetCategorias();

            cboCategoria.ItemsSource = cbll.GetCategorias();
            cboCategoria.SelectedIndex = 0;



        }

        private void BtnNuevaCategoria_Click(object sender, RoutedEventArgs e)
        {


            //Validaciones de campo vacío

            cbll.Add(txtCategoria.Text.Trim());
            txtCategoria.Text = string.Empty;

            CargarCategorias();
            
        }

        private void BtnEliminarCategoria_Click(object sender, RoutedEventArgs e)
        {
            string borrar = lstCategorias.SelectedItem.ToString();
            cbll.Delete(borrar);
            CargarCategorias();
        }

        private void BtnModificarCategoria_Click(object sender, RoutedEventArgs e)
        {
            string editar = lstCategorias.SelectedItem.ToString();
            catEditar = cbll.Find(editar);
            txtCategoria.Text = catEditar.Nombre;
            btnNuevaCategoria.Visibility = Visibility.Hidden;
            btnGuardarCambios.Visibility = Visibility.Visible;
            btnCancelarCambios.Visibility = Visibility.Visible;
        }

        private void BtnCancelarCambios_Click(object sender, RoutedEventArgs e)
        {
            btnNuevaCategoria.Visibility = Visibility.Visible;
            btnGuardarCambios.Visibility = Visibility.Hidden;
            btnCancelarCambios.Visibility = Visibility.Hidden;

            catEditar = null;
            txtCategoria.Text = string.Empty;
        }

        private void BtnGuardarCambios_Click(object sender, RoutedEventArgs e)
        {
            string nuevoNombre = txtCategoria.Text.Trim();
            cbll.Edit(catEditar.Nombre, nuevoNombre);
            CargarCategorias();
        }

        private void ChkFechaVencimiento_Checked(object sender, RoutedEventArgs e)
        {
            dtFechaVencimiento.IsEnabled = true;
        }

        private void ChkFechaVencimiento_Unchecked(object sender, RoutedEventArgs e)
        {
            dtFechaVencimiento.IsEnabled = false;
        }

        private void BtnCrearTarea_Click(object sender, RoutedEventArgs e)
        {
            string titulo = txtTitulo.Text.Trim();
            string detalle = txtCuerpo.Text.Trim();

            Nullable<DateTime> fechaVencimiento = null;
            if ((bool)chkFechaVencimiento.IsChecked)
            {
                fechaVencimiento = (DateTime)dtFechaVencimiento.SelectedDate;
            }

            string estado = cboEstado.SelectedValue.ToString();

            Categoria categoria = (Categoria)cboCategoria.SelectedItem;

            tbll.Add(titulo, detalle, fechaVencimiento, estado, categoria);

            CargarTareas();

            txtTitulo.Text = string.Empty;
            txtCuerpo.Text = string.Empty;
            dtFechaVencimiento.SelectedDate = DateTime.Today;
            chkFechaVencimiento.IsChecked = true;
            cboEstado.SelectedIndex = 0;
            cboCategoria.SelectedIndex = 0;
           
        }

        private void BtnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            string estado = cboFiltroEstado.SelectedValue.ToString();
            dgTareas.ItemsSource = tbll.GetTareasPorEstado(estado);
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            CargarTareas();
        }
    }
}
