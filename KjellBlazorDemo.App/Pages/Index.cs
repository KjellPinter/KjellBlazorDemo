using KjellBlazorDemo.App.Components;
using KjellBlazorDemo.App.Logic;
using KjellBlazorDemo.Engine.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System.Timers;

namespace KjellBlazorDemo.App.Pages
{
    public partial class Index
    {
        //[Inject]

        private SettingsDialog SettingsDialog { get; set; }
        private MessageDialog MessageDialog { get; set; }
        private DecisionDialog DecisionDialog { get; set; }

        private Interactions Interactions = new Interactions();
        private AssetManager AssetManager = new AssetManager();
        private List<Asset> AssetList = new List<Asset>();

        private ElementReference mainDiv;
        private System.Timers.Timer? _timer;

        string Message { get; set; }

        public Index()
        {
            SettingsDialog = new SettingsDialog();
            MessageDialog = new MessageDialog();
            DecisionDialog = new DecisionDialog();
            AssetManager.ResetAssets(AssetList);
            Message = "Move with the arrow keys and pick up the discarded cans";
        }


        private void HandleKeyDown(KeyboardEventArgs a)
        {
            Controls.KeyDown(a.Code);

            if (a.Code == "Space") { Message = ""; }
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
            Interactions.CollisionDetect(AssetList, Player);

            if (AssetList.Where(o => o.Name == "trash").Count() < 5)
            {
                Message = "press space for your special move";
            }

                if (AssetList.Where(o => o.Name == "trash").Count() == 0)
            {
                MessageDialog.Show("You've collected all the trash, the potato troll thanks you. ");
                AssetManager.ResetAssets(AssetList);
            }


            this.StateHasChanged();
        }

        public void ShowAbout()
        {
            MessageDialog.Show("This is a project for me to play in and learn. All the art is from opengameart.org. ");
        }
        public void ShowSettings()
        {
            SettingsDialog.Show();
        }

    }

}
