﻿using PokerPlanning.ViewModels;
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
	public partial class CreateRoomPage : ContentPage
	{
        private CreateRoomViewModel viewModel;
		public CreateRoomPage ()
		{
			InitializeComponent();
            this.BindingContext  = this.viewModel = new CreateRoomViewModel();
		}
	}
}