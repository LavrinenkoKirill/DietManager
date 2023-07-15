using System;
using System.IO;
using Xamarin.Essentials;
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
            Logo.Source = ImageSource.FromResource("DietManager.images.logo2.png");
        }


        protected async void ButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Gender());
        }

        protected async void ContinueProgramClick(object sender, EventArgs e)
        {
            string dayPath = Path.Combine(FileSystem.CacheDirectory, "Day.txt");
            if (File.Exists(dayPath)) await Navigation.PushAsync(new PlanPage());
            else
            {
                await DisplayAlert("Ошибка загрузки программы", "Программа не найдена", "ОК");
                return;
            }
        }
    }
}
