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
using DAL;
using BLL;
namespace main
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        InscripcionBLL ibll = new InscripcionBLL();
        ListaBLL lbll = new ListaBLL();
        public MainWindow()
        {
            InitializeComponent();
            DpFecha.SelectedDate = DateTime.Today;
            cmbPelicula.ItemsSource = Enum.GetValues(typeof(Pelicula));
            cmbJornada.ItemsSource = Enum.GetValues(typeof(Jornada));

        }
        int Total = 0;
        int mMatine = 0;
        int mTarde = 0;
        int mTrasnoche = 0;
        int tMatine = 0;
        int tTarde = 0;
        int tTrasnoche = 0;
        int fMatine = 0;
        int fTarde = 0;
        int fTrasnoche = 0;
        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            int cantEntradas;
            Inscripcion insc = new Inscripcion();
            Cantidad iCant = new Cantidad();
            insc.Pelicula = (Pelicula)cmbPelicula.SelectedValue;
            insc.Jornada = (Jornada)cmbJornada.SelectedValue;
            cantEntradas = int.Parse(txtCantEntradas.Text);
            insc.CantidadEntradas = cantEntradas;
            insc.FechaAdquisicion = (DateTime)DpFecha.SelectedDate;
            insc.Nombre = txtNombre.Text;
            insc.Telefono = txtTelefono.Text;

            if (insc.Pelicula.ToString() == "Matrix")
            {
                if (insc.Jornada.ToString() == "Matiné")
                {
                    mMatine = mMatine + 1;
                }
                else if (insc.Jornada.ToString()== "Tarde")
                {
                    mTarde = mTarde +1;
                }
                else
                {
                    mTrasnoche = mTrasnoche + 1;
                }
            }
            if (insc.Pelicula.ToString() == "Timeless")
            {
                if (insc.Jornada.ToString() == "Matiné")
                {
                    tMatine= tMatine +1;
                }
                else if (insc.Jornada.ToString() == "Tarde")
                {
                    tTarde = tTarde +1;
                }
                else
                {
                    tTrasnoche = tTrasnoche + 1;
                }
            }
            if(insc.Pelicula.ToString() == "Frozen")
            {
                if (insc.Jornada.ToString() == "Matiné")
                {
                    fMatine= fMatine + 1;
                }
                else if (insc.Jornada.ToString() == "Tarde")
                {
                    fTarde = fTarde +1;
                }
                else
                {
                    fTrasnoche= fTrasnoche +1;
                }
            }
            iCant.MatrixMatine = mMatine;
            iCant.MatrixTarde = mTarde;
            iCant.MatrixTrasnoche = mTrasnoche;
            iCant.TimelessMatine = tMatine;
            iCant.TimelessTarde = tTarde;
            iCant.TimelessTrasnoche = tTrasnoche;
            iCant.FrozenMatine = fMatine;
            iCant.FrozenTarde = fTarde;
            iCant.FrozenTrasnoche = fTrasnoche;


            if (insc.CantidadEntradas < 1 | insc.CantidadEntradas >5)
            {
                MessageBox.Show("Error, La cantidad de entradas puede ser de 1 hasta un maximo de 5...");
            }
            else if (insc.Nombre.Trim() == "")
            {
                MessageBox.Show("Error, El nombre no puede estar vacio...");
            }
            else if (insc.Telefono.Trim() == "")
            {
                MessageBox.Show("Error, El telefono no puede estar vacio...");
            }
            else
            {
                ibll.Agregar(insc);
                lbll.Agregar(iCant);
                Total++;
                LbTotal.Content = Total;
            }

            
        }

        private void BtnListar_Click(object sender, RoutedEventArgs e)
        {
            LstRegistradas.ItemsSource = null;
            LstRegistradas.ItemsSource = ibll.GetAll();
            LstCant.ItemsSource = null;
            LstCant.ItemsSource = lbll.GetAll(); 
        }
    }
}
