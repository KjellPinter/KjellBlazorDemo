using KjellBlazorDemo.App.Components;
using KjellBlazorDemo.App.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System.Timers;

namespace KjellBlazorDemo.App.Pages
{
    public partial class Index
    {
        //[Inject]

        protected SettingsDialog SettingsDialog { get; set; }

        protected List<Trash> TrashList { get; set; }

        private ElementReference mainDiv;
        private System.Timers.Timer? _timer;

        public Index()
        {
            SettingsDialog = new SettingsDialog();

            //populate trash
            TrashList = new List<Trash>();
            var rnd = new Random();

            for(int i = 0; i < 5; i++)
            {
                int t = rnd.Next(500);
                int l = rnd.Next(500);
                TrashList.Add(new Trash(t, l));
            }

        }


        private void HandleKeyDown(KeyboardEventArgs a)
        {
            Controls.KeyDown(a.Code);
        }

        protected override async Task OnAfterRenderAsync(bool first)
        {
            //removeing default "first" check as focus is continually getting set elsewhere, like on window
            if (!SettingsDialog.ShowDialog)
            {
                await mainDiv.FocusAsync();
                await JsRunTime.InvokeVoidAsync("OnScrollEvent");
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
            CollisionDetect();
            this.StateHasChanged();
        }

        private void CollisionDetect()
        {
            var cols = TrashList.Where(o => o.Left > (Player.PositionLeft - 2) && o.Left < (Player.PositionLeft) + 30
                            && o.Top > (Player.PositionTop - 2) && o.Top < (Player.PositionTop) + 30).ToList();

            if (cols.Count() > 0)
            {
                foreach (var c in cols)
                {
                    TrashList.Remove(c);
                }
            }
        }

        public void ShowSettings()
        {
            SettingsDialog.Show();
        }

    }

}
