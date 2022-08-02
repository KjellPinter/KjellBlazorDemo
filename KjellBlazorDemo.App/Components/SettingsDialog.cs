namespace KjellBlazorDemo.App.Components
{
    public partial class SettingsDialog
    {
        public bool ShowDialog { get; set; }

        public Engine.Settings settings = new Engine.Settings();



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
