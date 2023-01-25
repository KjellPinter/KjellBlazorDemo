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

            if (a.Code == "Digit1")
            {
                JsRunTime.InvokeVoidAsync("PlayAudioFile", "/Sounds/confusion.ogg");
            }
            
            if (a.Code == "Digit2") {
                JsRunTime.InvokeVoidAsync("PlayAudioFile", "/Sounds/zap.ogg");
            }

            if (a.Code == "Digit3")
            {
                JsRunTime.InvokeVoidAsync("PlayAudioFile", "/Sounds/flamethrower.ogg");
            }

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
            Player.Assets = AssetList; //Player manager needs reference to asset list so it can detect collisions

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

            if (!AssetList.Any(o => o.Name == "trash"))
            {
                Message = "Level 2";
                AssetManager.ResetAssets(AssetList, 2);
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
