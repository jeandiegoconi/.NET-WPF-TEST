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
        CategoriaBLL catBLL = new CategoriaBLL();
        public MainWindow()
        {
            InitializeComponent();
            ListarCategorias();
        }

        private void ListarCategorias()
        {
            LstCategorias.ItemsSource = catBLL.GetAll();
        }

        private void BtnAddCategoria_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nombre = TxtNombre.Text.Trim();
                catBLL.Add(nombre);

                MessageBox.Show("Categoria agregada", "Nueva Categoria", MessageBoxButton.OK, MessageBoxImage.Information);
                TxtNombre.Text = string.Empty;
                ListarCategorias();
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Nueva Categoria", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnEliminarCategoria_Click(object sender, RoutedEventArgs e)
        {
            string nombre = LstCategorias.SelectedItem.ToString();
            catBLL.Delete(nombre);

            ListarCategorias();
        }
    }
}
