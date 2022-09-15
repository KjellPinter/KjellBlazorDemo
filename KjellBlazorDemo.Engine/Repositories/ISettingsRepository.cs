using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KjellBlazorDemo.Engine.Repositories
{
    internal interface ISettingsRepository
    {
        Settings GetSettings();
        void SaveSettings(Settings settings);
    }
}
