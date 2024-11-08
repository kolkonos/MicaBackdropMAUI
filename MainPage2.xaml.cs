namespace MicaBackdropMAUI
{
    public partial class MainPage2 : ContentPage
    {
        public MainPage2()
        {
            InitializeComponent();
            menu_switch.IsToggled = Shell.Current.FlyoutBehavior == FlyoutBehavior.Locked;
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            Shell.Current.FlyoutBehavior = e.Value ? FlyoutBehavior.Locked : FlyoutBehavior.Flyout;
        }
    }
}
