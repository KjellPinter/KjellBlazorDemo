using KjellBlazorDemo.App.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Timers;

namespace KjellBlazorDemo.App.Pages
{
    public partial class Index
    {
        //[Inject]

        protected SettingsDialog SettingsDialog { get; set; }

        private ElementReference mainDiv;
        private System.Timers.Timer? _timer;

        public Index()
        {
            SettingsDialog = new SettingsDialog();
        }

        private void HandleKeyDown(KeyboardEventArgs a)
        {
            Controls.KeyDown(a.Code);
        }

        protected override async Task OnAfterRenderAsync(bool first)
        {
            if (first)
            {
                await mainDiv.FocusAsync();
            }
        }

        protected override Task OnInitializedAsync()
        {
            _timer = new System.Timers.Timer();
            _timer.Interval = 20;
            _timer.Elapsed += TimerElapsed;
            _timer.AutoReset = true;
            _timer.Enabled = true;

            return base.OnInitializedAsync();
        }

        private void TimerElapsed(Object? source, ElapsedEventArgs a)
        {
            Redraw();
        }

        private void Redraw()
        {
            this.StateHasChanged();
        }

        public void ShowSettings()
        {
            SettingsDialog.Show();
        }

    }

}
