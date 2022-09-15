using KjellBlazorDemo.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KjellBlazorDemo.App.Repositories
{
    public class SettingsRepository : ISettingsRepository
    {
        public Settings GetSettings()
        {
            return new Settings();
        }

        public void SaveSettings(Settings settings)
        {
            //JsonFileUtils.WriteFile(settings, @"c:\temp\Settings.json");
            throw new NotImplementedException();
        }
    }
}
