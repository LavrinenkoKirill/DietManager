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
            Male.Source = ImageSource.FromResource("DietManager.male1.png");
            Female.Source = ImageSource.FromResource("DietManager.female1.png");
            GenderBack.ImageSource = ImageSource.FromResource("DietManager.smb.png");
            GenderForward.ImageSource = ImageSource.FromResource("DietManager.smf.png");
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