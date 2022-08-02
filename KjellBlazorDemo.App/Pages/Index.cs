using KjellBlazorDemo.App.Components;
using Microsoft.AspNetCore.Components;

namespace KjellBlazorDemo.App.Pages
{
    public partial class Index
    {
        //[Inject]

        protected SettingsDialog SettingsDialog { get; set; }


        public Index()
        {
            SettingsDialog = new SettingsDialog();
        }

        public void ShowSettings()
        {
            SettingsDialog.Show();
        }

    }

}
