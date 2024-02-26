namespace TornFactionManagement
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private void OnFlyoutButtonClicked(object sender, EventArgs e)
        {
            FlyoutIsPresented = !FlyoutIsPresented;
        }
    }
}
