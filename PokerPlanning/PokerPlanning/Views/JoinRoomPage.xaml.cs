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
	public partial class JoinRoomPage : ContentPage
	{
        private JoinRoomViewModel viewModel;
		public JoinRoomPage ()
		{
			InitializeComponent ();
            this.BindingContext = this.viewModel = new JoinRoomViewModel();
		}
	}
}