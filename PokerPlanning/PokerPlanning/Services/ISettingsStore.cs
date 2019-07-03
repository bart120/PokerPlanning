using PokerPlanning.Models;
using PokerPlanning.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokerPlanning.Services
{
    public interface ISettingsStore
    {
        void SaveSettings(SettingsModel model);

        SettingsModel LoadSettings();

    }
}
