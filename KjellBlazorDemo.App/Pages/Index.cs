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
        private SettingsDialog SettingsDialog { get; set; }
        private MessageDialog MessageDialog { get; set; }
        private DecisionDialog DecisionDialog { get; set; }

        private readonly List<Asset> AssetList = new();

        private int HelpCounter = 0;
        private ElementReference mainDiv;
        private System.Timers.Timer? _timer;

        string Message { get; set; }

        public Index()
        {
            SettingsDialog = new SettingsDialog();
            MessageDialog = new MessageDialog();
            DecisionDialog = new DecisionDialog();
            
            Message = "Move with the arrow keys and pick up the discarded cans";
        }

        private void HandleKeyDown(KeyboardEventArgs a)
        {
            Controls.KeyDown(a.Code);
        }

        private void HandleKeyUp(KeyboardEventArgs a)
        {
            Controls.KeyUp(a.Code);
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
            AssetManager.ResetAssets(AssetList);

            _timer = new System.Timers.Timer
            {
                Interval = 20 // Settings.GAME_TICK;
            };
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
            Interactions.CollisionDetect(AssetList, Player, Logic);

            if (AssetList.Count(o => o.Name == "trash") < 5)
            {
                if (HelpCounter == 0)
                {
                    Message = "press space for your special move";
                    HelpCounter = 1;
                }
            }

            if (!AssetList.Any(o => o.Name == "trash"))
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
