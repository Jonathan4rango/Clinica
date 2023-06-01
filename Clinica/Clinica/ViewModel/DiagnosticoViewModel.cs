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

    internal class DiagnosticoViewModel : BaseViewModel
    {

        #region Atributos

        private string codigo;
        private string nombre;
       

        #endregion

        #region Prop

        public string CodigoTxt
        {
            get
            {
                return this.codigo;
            }
            set { SetValue(ref this.codigo, value); }
        }


        public string NombresTxt
        {
            get
            {
                return this.nombre;
            }
            set { SetValue(ref this.nombre, value); }
        }

      


        #endregion

        #region Commands

        public ICommand GuardarDCommand
        {
            get
            {
                return new RelayCommand(RegistrarPaciente);
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
        




        #endregion


        public async void BorrarLista()
        {
            CodigoTxt = "";
            NombresTxt = "";
           

            await Application.Current.MainPage.DisplayAlert("Register", "Limpiaste el formulario", "Aceptar");

        }
       


        public async void RegistrarPaciente()
        {


            if (string.IsNullOrEmpty(this.codigo))
            {
                await Application.Current.MainPage.DisplayAlert("Register", "Por favor Ingresar el Usuario", "Aceptar");
                CodigoTxt = "";
                return;
            }


            DiagnosticoModel Diag = new DiagnosticoModel();
            Diag.Codigo = codigo;
            Diag.Nombre = nombre;
            



            await App.DB.SaveModelAsync<DiagnosticoModel>(Diag, true);
            await Application.Current.MainPage.DisplayAlert("Register", " Registro Exitoso", "Aceptar");


        }
    }
}
