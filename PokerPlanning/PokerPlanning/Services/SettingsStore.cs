using Newtonsoft.Json;
using PokerPlanning.Models;
using PokerPlanning.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace PokerPlanning.Services
{
    public class SettingsStore : ISettingsStore
    {
        private const string  SETTINGS = "SETTINGS";

        public void SaveSettings(SettingsModel model)
        {
            Preferences.Set(SETTINGS, JsonConvert.SerializeObject(model));
        }

        public SettingsModel LoadSettings()
        {
            return JsonConvert.DeserializeObject<SettingsModel>( Preferences.Get(SETTINGS, ""));
        }

       
    }
}
