using KjellBlazorDemo.Engine.Interfaces;
using KjellBlazorDemo.Engine.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace KjellBlazorDemo.App.Components
{
    public partial class SettingsDialog
    {
        public bool ShowDialog { get; set; }

        public Engine.Settings settings = new Engine.Settings();

        public List<Character> Characters = new List<Character>();
        
        public SettingsDialog()
        {
           
        }

        protected override async Task OnInitializedAsync()
        {
            Characters = await Http.GetFromJsonAsync<List<Character>>("Data/Characters.json");
        }




        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        public void Show()
        {
            ShowDialog = true;
            StateHasChanged();
        }

        
    }
}
