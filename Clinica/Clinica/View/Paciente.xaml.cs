using Clinica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Clinica.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Paciente : ContentPage
	{
		public Paciente ()
		{
			InitializeComponent ();
            BindingContext = new PacienteViewModel();
        }
	}
}