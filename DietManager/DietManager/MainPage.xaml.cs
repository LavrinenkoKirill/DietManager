using System;
using Xamarin.Forms;

namespace DietManager
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Logo.Source = ImageSource.FromResource("DietManager.logo2.png");
        }


        protected async void ButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Gender());
        }

        protected async void ContinueProgramClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlanPage());
        }
    }
}
