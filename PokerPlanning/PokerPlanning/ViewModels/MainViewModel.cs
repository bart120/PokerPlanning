using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PokerPlanning.ViewModels
{
    public class MainViewModel
    {
        public event Action<int, string> onjoinRoom;
        public ICommand AddRoomCommand { get; set; }

        public ICommand JoinRoomCommand { get; set; }

        public MainViewModel()
        {


            this.AddRoomCommand = new Command(() =>
            {

            });
        }
        
    }
}
