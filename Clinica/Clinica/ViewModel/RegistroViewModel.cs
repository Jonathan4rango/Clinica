using Clinica.Model;
using Clinica.View;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;




namespace Clinica.ViewModel
{
    internal class RegistroViewModel : BaseViewModel
    {



        #region Atributos
        private string usr;
        private string pass;
        private string nombre;
        private string Apellido;
        private string correo;
        private string contrasena;
        private string telefono;
        private string usuario;



        #endregion


        #region Propiedades


        public string NombreTxt
        {
            get {
                return this.nombre; 
                } 

            set { 
                   SetValue(ref this.nombre, value);
                }
        }

        public string ApellidoTxt
        {
            get
            {
                return this.Apellido;
            }

            set
            {
                SetValue(ref this.Apellido, value);
            }
        }
        public string CorreoTxt
        {
            get
            {
                return this.correo;
            }

            set
            {
                SetValue(ref this.correo, value);
            }
        }
        public string ContrasenaTxt
        {
            get
            {
                return this.contrasena;
            }

            set
            {
                SetValue(ref this.contrasena, value);
            }
        }
        public string TeléfonoTxt
        {
            get
            {
                return this.telefono;
            }

            set
            {
                SetValue(ref this.telefono, value);
            }
        }
        public string UsuarioTxt
        {
            get
            {
                return this.usuario;
            }

            set
            {
                SetValue(ref this.usuario, value);
            }
        }

        #endregion

        #region Method

        public ICommand RegistrarseCommand
        {
            get
            {
                return new RelayCommand(RegistrarUsuario);
            }

            set { }

        }


        public ICommand IrLoginCommand
        {
            get
            {
                return new RelayCommand(IrRegistro);
            }

            set { }

        }

        public ICommand IngresarCommand
        {
            get
            {
                return new RelayCommand(GoPrincipal);
            }

            set { }

        }

        public ICommand LimpiarCommand
        {
            get
            {
                return new RelayCommand(Limpiar);
            }

            set { }

        }


        public async void RegistrarUsuario()
        {


            if (string.IsNullOrEmpty(this.usuario))
            {
                await Application.Current.MainPage.DisplayAlert("Register", "Por favor Ingresar el Usuario", "Aceptar");
                contrasena = "";
                return;
            }


            RegistroModel Usr = new RegistroModel();
            Usr.Nombre = nombre;
            Usr.Apellido = Apellido;
            Usr.Correo = correo;
            Usr.Contrasena = contrasena;
            Usr.Telefono = telefono;
            Usr.Usuario = usuario;
          


            await App.DB.SaveModelAsync<RegistroModel>(Usr, true);
            await Application.Current.MainPage.DisplayAlert("Register", " Registro Exitoso", "Aceptar");


        }



        #endregion


        public async void Limpiar()
        {

            UsuarioTxt = "";
            ContrasenaTxt = "";
            await Application.Current.MainPage.DisplayAlert("Login", "Limpiaste pantalla", "Aceptar");
        }

        public async void IrRegistro()
        {

            await Application.Current.MainPage.Navigation.PushAsync(new Registro());

        }

        public async void GoPrincipal()
        {
            RegistroModel Usr = App.DB.GetRegistromodel(usuario, contrasena).Result;

            if (Usr == null)
            {
                await Application.Current.MainPage.DisplayAlert("Login", "Credenciales incorrectas", "Aceptar");
            }
            else
            {
                //Application.Current.MainPage = new Principal();
               await Application.Current.MainPage.Navigation.PushAsync(new Principal());
            }

        }
    }
}
