using PokerPlanning.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokerPlanning.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
        private SettingsViewModel viewModel;

        public SettingsPage ()
		{
			InitializeComponent ();

            this.BindingContext = this.viewModel = new SettingsViewModel();
		}
	}
}