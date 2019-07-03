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

        private SettingsModel model;

        public void SaveSettings(SettingsModel model)
        {
            Preferences.Set(SETTINGS, JsonConvert.SerializeObject(model));
            this.model = model;
        }

        public SettingsModel LoadSettings()
        {
            if(this.model == null)
                this.model = JsonConvert.DeserializeObject<SettingsModel>( Preferences.Get(SETTINGS, ""));
            return this.model;
        }

       
    }
}
