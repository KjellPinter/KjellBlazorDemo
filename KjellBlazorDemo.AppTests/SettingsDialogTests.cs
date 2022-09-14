using KjellBlazorDemo.App.Components;
using KjellBlazorDemo.Engine;
using KjellBlazorDemo.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KjellBlazorDemo.AppTests
{
    public class SettingsDialogTests
    {

        [Fact]
        public void SettingsPopulate()
        {
            // arrange
            var ctx = new TestContext();

            ctx.Services.AddMockHttpClient();
            ctx.Services.AddSingleton<IPlayerManager, PlayerManager>();
            ctx.Services.AddSingleton<Settings>();

            var sets = new Settings();

            // act            
            var comp = ctx.RenderComponent<SettingsDialog>();
            var distance = comp.Find("#MOVEMENT_DISTANCE");
            var charsel = comp.Find("#selectCharacter");

            // assert
            Assert.Equal(distance.GetAttribute("value").ToString(), sets.MOVEMENT_DISTANCE.ToString());
            Assert.Equal(charsel.GetAttribute("value").ToString(), sets.CHARACTER.ToString());

        }
    }
}
