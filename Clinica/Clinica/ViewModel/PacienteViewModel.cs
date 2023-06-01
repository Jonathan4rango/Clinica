using Clinica.Model;
using Clinica.View;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Clinica.ViewModel
{
   internal class PacienteViewModel : BaseViewModel
    {

        #region Atributos

        private string cedula;
        private string nombre;
        private string apellido;
        private string correo;      
        private string fecha;
        
        #endregion

        #region Prop

        public string CedulaTxt
        {
            get
            {
                return this.cedula;
            }
            set { SetValue(ref this.cedula, value); }
        }


        public string NombresTxt
        {
            get
            {
                return this.nombre;
            }
            set { SetValue(ref this.nombre, value); }
        }

        public string ApellidosTxt
        {
            get
            {
                return this.apellido;
            }
            set { SetValue(ref this.apellido, value); }
        }

        public string CorreoTxt
        {
            get
            {
                return this.correo;
            }
            set { SetValue(ref this.correo, value); }
        }

        public string FechaTxt
        {
            get
            {
                return this.fecha;
            }
            set { SetValue(ref this.fecha, value); }
        }


       
        #endregion

        #region Commands

        public ICommand RegistrarPCommand
        {
            get
            {
                return new RelayCommand(IrPaciente);
            }

            set { }

        }
        public ICommand BorrarCommand
        {
            get
            {
                return new RelayCommand(BorrarLista);
            }

            set { }

        }
        public ICommand GuardarPCommand
        {
            get
            {
                return new RelayCommand(RegistrarPaciente);
            }

            set { }

        }

        public ICommand IngresarDCommand
        {
            get
            {
                return new RelayCommand(IrDiag);
            }

            set { }

        }

        public ICommand IngresarICommand
        {
            get
            {
                return new RelayCommand(IrInc);
            }

            set { }

        }




        #endregion


        public async void BorrarLista()
        {
            CedulaTxt = "";
            NombresTxt = "";
            ApellidosTxt = "";
            CorreoTxt = "";
            FechaTxt = "";

            await Application.Current.MainPage.DisplayAlert("Register", "Limpiaste el formulario", "Aceptar");

        }
        public async void IrPaciente()
        {

            await Application.Current.MainPage.Navigation.PushAsync(new Paciente());

        }

        public async void IrDiag()
        {

            await Application.Current.MainPage.Navigation.PushAsync(new Diagnostico());

        }
        public async void IrInc()
        {

            await Application.Current.MainPage.Navigation.PushAsync(new Incapacidad());

        }

        public async void RegistrarPaciente()
        {


            if (string.IsNullOrEmpty(this.cedula))
            {
                await Application.Current.MainPage.DisplayAlert("Register", "Por favor Ingresar el Usuario", "Aceptar");
                CedulaTxt = "";
                return;
            }


          PacienteModel Pac = new PacienteModel();
            Pac.Cedula = cedula;
            Pac.Nombre = nombre;
            Pac.Apellido = apellido;
            Pac.Correo = correo;
            Pac.Fecha = fecha;
           



            await App.DB.SaveModelAsync<PacienteModel>(Pac, true);
            await Application.Current.MainPage.DisplayAlert("Register", " Registro Exitoso", "Aceptar");


        }
    }
}
