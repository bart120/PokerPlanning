﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PokerPlanning.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected bool SetProperty<T>(ref T backingStore, T value, 
            [CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            onChanged?.Invoke();
            return true;
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
