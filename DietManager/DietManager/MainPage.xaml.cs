using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Logo.Source = ImageSource.FromResource("DietManager.logo1.png");
        }


        protected async void ButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Gender());
        }

        protected async void ContinueProgramClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlanPage("Female",170,80,75,8));
        }
    }
}
