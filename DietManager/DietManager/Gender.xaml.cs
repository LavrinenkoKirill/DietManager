using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DietManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Gender : ContentPage
    {
        public Gender()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Male.Source = ImageSource.FromResource("DietManager.images.highblur.png");
            Female.Source = ImageSource.FromResource("DietManager.images.fblur.png");
            GenderBack.ImageSource = ImageSource.FromResource("DietManager.images.smb.png");
            GenderForward.ImageSource = ImageSource.FromResource("DietManager.images.smf.png");
        }

        protected async void GenderClick(object sender, EventArgs e)
        {
            string gender;
            if (MaleButton.IsChecked) gender = "Male";
            else if (FemaleButton.IsChecked) gender = "Female";
            else
            {
                await DisplayAlert("Выбор пола", "Пожалуйста, выберите пол среди указанных вариантов", "ОК");
                return;

            }
            await Navigation.PushAsync(new HeightPage(gender));
        }

        protected async void GenderBackClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }


    }
}