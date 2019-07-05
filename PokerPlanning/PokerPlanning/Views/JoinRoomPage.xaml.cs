using LibPockerPlanning;
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
    public partial class JoinRoomPage : ContentPage
    {
        private JoinRoomViewModel viewModel;
        public JoinRoomPage()
        {
            InitializeComponent();
            this.BindingContext = this.viewModel = new JoinRoomViewModel();
        }

        private async void RoomsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var room = e.SelectedItem as RoomModel;
                if (room.Locked)
                    ((ListView)sender).SelectedItem = null;
                else
                    await Navigation.PushModalAsync(new RoomPage());
            }
        }
    }
}