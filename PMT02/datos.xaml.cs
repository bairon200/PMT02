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
    public partial class datos : ContentPage
    {

       

        public datos()
        {
            InitializeComponent();

        }

        private async void btnvolver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void btnguardar_Clicked(object sender, EventArgs e)
        {
            
            if (validarDatos())
            {
                var fechaformato=txtfecha.Date.ToShortDateString(); 

               

                Datos datos = new Datos
                {
                    Nombre=txtnombre.Text,
                    Edad=int.Parse(txtedad.Text),
                    Fecha = fechaformato,
                    Direccion =txtDireccion.Text,    
                    Sexo=picker.SelectedItem.ToString(),    
                };  
                await App.SQLiteDB.SaveDatosAsync(datos);

                txtnombre.Text = "";
                txtedad.Text = "";
                txtDireccion.Text = "";
                picker.SelectedItem="Seleccionar Sexo";
                await DisplayAlert("Registro", "Se guardo de manera exitosa los datos", "Ok");

            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresar todos los datos", "Ok");
            }
        }

       

        public bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtnombre.Text))
            {
                respuesta = false;  
            }
            else if(string.IsNullOrEmpty(txtedad.Text)) 
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                respuesta = false;
            }
           
            else {
                respuesta = true; 
            }  
            return respuesta;   
        }

        private async void btnlista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaPersonas());
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
          

            if (string.IsNullOrEmpty(txtIddatos.Text))
            {

                var fechaformato = txtfecha.Date.ToShortDateString();

               Datos datos = new Datos()
                {
                    

                    id = Convert.ToInt32(txtIddatos.Text),
                    Nombre =txtnombre.Text,
                    Edad = Convert.ToInt32(txtedad.Text),
                    Fecha = fechaformato,
                    Direccion = txtDireccion.Text,  

                };
                await App.SQLiteDB.SaveDatosAsync(datos);

                await DisplayAlert("Registro", "Se Actualizo de manera exitosa", "Ok");

                txtnombre.Text = "";
                txtedad.Text = "";
                txtDireccion.Text = "";
               

            }
        }


    }
}