using PokerPlanning.Services;
using PokerPlanning.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokerPlanning
{
    public partial class MainPage : TabbedPage
    {

        public MainPage()
        {
            InitializeComponent();
            if(DependencyService.Get<ISettingsStore>(DependencyFetchTarget.GlobalInstance).LoadSettings() == null)
                this.CurrentPage = this.Children[2];
            
        }
    }
}
