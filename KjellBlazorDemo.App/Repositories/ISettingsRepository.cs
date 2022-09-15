using KjellBlazorDemo.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KjellBlazorDemo.App.Repositories
{
    internal interface ISettingsRepository
    {
        Settings GetSettings();
        void SaveSettings(Settings settings);
    }
}
