using KjellBlazorDemo.App.Components;
using KjellBlazorDemo.App.Logic;
using KjellBlazorDemo.Engine;
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
            
            Message = "";
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

            if (a.Code == "Digit4")
            {
                JsRunTime.InvokeVoidAsync("PlayAudioFile", "/Sounds/meow.ogg");
            }
            
        }

        
        private void HandleKeyUp(KeyboardEventArgs a)
        {
            Controls.KeyUp(a.Code);
        }

        protected override async Task OnAfterRenderAsync(bool first)
        {
            if (first)
            {
                MessageDialog.Show("Welcome to KjellBlazorDemo!",
                "Use the arrow or WASD keys to move the player.",
                "Numeric keys 1-4 are your spells.",
                "You cannot move through walls but the troll(s) can (at the moment)");
            }

            if (!SettingsDialog.ShowDialog)
            {
                await mainDiv.FocusAsync();
                await JsRunTime.InvokeVoidAsync("OnScrollEvent");
            }
        }
        
        protected async Task SetDimensions()
        {
            try
            {
                BrowserDimension bd = await JsRunTime.InvokeAsync<BrowserDimension>("getDimensions");
                Settings.MAX_X = bd.Width - 10;
                Settings.MAX_Y = bd.Height - 30;
            }
            catch(Exception ex)
            {
                //this fails from test suite, that is ok
            }
            
            return;
        }

        protected override async Task<Task> OnInitializedAsync()
        {
            //set settings max based on window size
            await SetDimensions(); //.Wait();
            
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

    public class BrowserDimension
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
