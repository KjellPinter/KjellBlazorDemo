using KjellBlazorDemo.App.Components;
using KjellBlazorDemo.App.Logic;
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
        public void SettingsDialogOpensAndPopulates()
        {
            // arrange
            var ctx = new TestContext();
            ctx.JSInterop.Mode = JSRuntimeMode.Loose;

            ctx.Services.AddMockHttpClient();
            ctx.Services.AddSingleton<IPlayerManager, PlayerManager>();
            ctx.Services.AddSingleton<IControls, Controls>();
            ctx.Services.AddSingleton<Settings>();
            ctx.Services.AddSingleton<ILogic, Engine.Logic>();
            ctx.Services.AddSingleton<Interactions>();
            ctx.Services.AddSingleton<AssetManager>();

            var sets = new Settings();

            // act            
            var comp = ctx.RenderComponent<App.Pages.Index>();
            comp.Find("#settingsMenuItem").Click();
            var distance = comp.Find("#MOVEMENT_DISTANCE");
            var charsel = comp.Find("#selectCharacter");

            // assert
            Assert.Equal(distance.GetAttribute("value")!.ToString(), sets.MOVEMENT_DISTANCE.ToString());
            Assert.Equal(charsel.GetAttribute("value")!.ToString(), sets.CHARACTER.ToString());

        }
    }
}
