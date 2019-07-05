
using LibPockerPlanning;
using PokerPlanning.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokerPlanning.ViewModels
{
    public class JoinRoomViewModel : BaseViewModel
    {
        private ISettingsStore settingsStore;
        private IRoomStore roomStore;

        public ObservableCollection<RoomModel> Rooms { get; set; }

        public JoinRoomViewModel()
        {
            //checkedexeptions addon
            this.settingsStore = DependencyService.Get<ISettingsStore>(DependencyFetchTarget.GlobalInstance);
            this.roomStore = DependencyService.Get<IRoomStore>(DependencyFetchTarget.GlobalInstance);

            ((RoomStore)this.roomStore).CreateRoomEvent += JoinRoomViewModel_CreateRoomEvent;
        }

        private async Task JoinRoomViewModel_CreateRoomEvent(RoomModel arg)
        {
            this.Rooms.Add(arg);
        }
    }
}
