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
        protected MessageDialog MessageDialog { get; set; }

        protected List<Asset> AssetList { get; set; }
        protected List<Mob> Mobs { get; set; }

        private ElementReference mainDiv;
        private System.Timers.Timer? _timer;

        public Index()
        {
            SettingsDialog = new SettingsDialog();
            MessageDialog = new MessageDialog();

            
            AssetList = new List<Asset>();
            AssetList.Add(new Mob("troll"));

            PopulateTrash(5);
        }

        private void PopulateTrash(int amount)
        {
            
            var rnd = new Random();

            for (int i = 0; i < amount; i++)
            {
                int t = rnd.Next(500);
                int l = rnd.Next(500);
                AssetList.Add(new Trash(t, l));
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
            var cols = AssetList.Where(o => o.Left > (Player.PositionLeft - 34) && o.Left < (Player.PositionLeft) + 2
                            && o.Top > (Player.PositionTop - 34) && o.Top < (Player.PositionTop) + 2).ToList();

            Mob troll = (Mob)AssetList.Where(o => o.Name == "troll").FirstOrDefault();

            if (cols.Count() > 0)
            {
                //test mob attack
                troll.IsAttacking = true;

                foreach (var c in cols)
                {
                    AssetList.Remove(c);
                }
            }

            //mob attack test - todo: refactor all the troll stuff in this method
            if (troll.IsAttacking)
            {
                if (troll.Top < Player.PositionTop)
                {
                    ++troll.Top;
                }

                if (troll.Top > Player.PositionTop)
                {
                    --troll.Top;
                }

                if (troll.Left < Player.PositionLeft)
                {
                    ++troll.Left;
                }

                if (troll.Left > Player.PositionLeft)
                {
                    --troll.Left;
                }
            }

            if (AssetList.Where(o => o.Name == "trash").Count() == 0)
            {
                MessageDialog.Show("You've collected all the trash, the potato troll thanks you. ");
                PopulateTrash(10);
            }
        }

        public void ShowAbout()
        {
            MessageDialog.Show("This is a project for me to play in and learn.");
        }
        public void ShowSettings()
        {
            SettingsDialog.Show();
        }

    }

}
