using KjellBlazorDemo.Engine.Interfaces;
using KjellBlazorDemo.Engine.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace KjellBlazorDemo.App.Components
{
    public partial class SettingsDialog
    {
        public bool ShowDialog { get; set; }

        public List<Character> Characters = new List<Character>();
        
        public SettingsDialog()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            Characters = await Http.GetFromJsonAsync<List<Character>>("Data/Characters.json");
        }

        public void SaveChanges()
        {
            Player.Character = Characters[settings.CHARACTER - 1];
            ShowDialog = false;
            StateHasChanged();
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
