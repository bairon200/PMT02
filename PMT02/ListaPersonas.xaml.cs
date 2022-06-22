using PMT02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PMT02
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaPersonas : ContentPage
    {

        public static string iddatos;
        public static string nombre;
        public static string edad;
        public static string fecha;
        public static string direccion;
        public static string sexoPiker;


        public ListaPersonas()
        {
            InitializeComponent();
            mostrarLista();
        }

        public async void mostrarLista()
        {
            var datoslist = await App.SQLiteDB.GetDatosAsync();
            if (datoslist != null)
            {
                listadatos.ItemsSource = datoslist;
            }
        }

        private async void btnvolver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new datos());   
        }

 

        public async  void listadatos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {


            var obj = (Datos)e.SelectedItem;
           
            if (!string.IsNullOrEmpty(obj.id.ToString()))
            {
                var datos2 = await App.SQLiteDB.GetDatosByIdAsync(obj.id);

                if (datos2 != null)
                {

                    iddatos = datos2.id.ToString();
                    nombre = datos2.Nombre;
                    edad = datos2.Edad.ToString();
                    fecha = datos2.Fecha;
                    direccion = datos2.Direccion.ToString();
                    sexoPiker = datos2.Sexo.ToString();

                    var mandar = new Models.pasarDatos

                    {
                       idp =Convert.ToInt32( iddatos.ToString()),
                       Nombrep=nombre,
                       Edadp = Convert.ToInt32(edad.ToString()),
                       Fechap = fecha,
                       Direccionp = direccion,
                       Sexop = sexoPiker

                    };

                    var segpage = new Actualizar();
                    segpage.BindingContext = mandar;
                   await Navigation.PushAsync(segpage);


                }
              

            }

           // await Navigation.PushAsync(new Actualizar());

        }
    }
}