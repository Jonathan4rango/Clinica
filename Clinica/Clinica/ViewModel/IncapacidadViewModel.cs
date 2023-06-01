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
    internal class IncapacidadViewModel : BaseViewModel
    {

        #region Atributos

        private string ninc;
        private string dias;
        private string fecha;
        private string cedula;
     

        #endregion

        #region Prop

        public string IncapacidadTxt
        {
            get
            {
                return this.ninc;
            }
            set { SetValue(ref this.ninc, value); }
        }


        public string DiasTxt
        {
            get
            {
                return this.dias;
            }
            set { SetValue(ref this.dias, value); }
        }

        public string FechaTxt
        {
            get
            {
                return this.fecha;
            }
            set { SetValue(ref this.fecha, value); }
        }

        public string CedulaTxt
        {
            get
            {
                return this.cedula;
            }
            set { SetValue(ref this.cedula, value); }
        }

       



        #endregion

        #region Commands

        public ICommand GuardarPCommand
        {
            get
            {
                return new RelayCommand(SaveInca);
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
            IncapacidadTxt = "";
            DiasTxt = "";
            FechaTxt = "";
            CedulaTxt = "";
            

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

        public async void SaveInca()
        {


            if (string.IsNullOrEmpty(this.ninc))
            {
                await Application.Current.MainPage.DisplayAlert("Register", "Por favor Ingresar el Usuario", "Aceptar");
                IncapacidadTxt = "";
                return;
            }


            IncapacidadModel Pac = new IncapacidadModel();
            Pac.NIncapa = ninc;
            Pac.Dias = dias;
            Pac.Fecha = fecha;
            Pac.Cedula = cedula;
           




            await App.DB.SaveModelAsync<IncapacidadModel>(Pac, true);
            await Application.Current.MainPage.DisplayAlert("Register", " Registro Exitoso", "Aceptar");


        }
    }
}
