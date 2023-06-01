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
	public partial class Diagnostico : ContentPage
	{
		public Diagnostico ()
		{
			InitializeComponent ();
            BindingContext = new DiagnosticoViewModel();
        }
	}
}