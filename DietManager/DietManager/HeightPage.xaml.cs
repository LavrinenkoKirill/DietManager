using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DietManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeightPage : ContentPage
    {
        private string gender;
        public HeightPage(string gender)
        {
            InitializeComponent();
            this.gender = gender;
        }

        protected override void OnAppearing()
        {

            if (gender == "Male")
            {
                LinearGradientBrush br = new LinearGradientBrush();
                br.StartPoint = new Point(1, 0);
                br.EndPoint = new Point(0, 1);
                GradientStop FirstColor = new GradientStop();
                GradientStop SecondColor = new GradientStop();
                FirstColor.Color = Color.FromHex("AB74EBD5");
                SecondColor.Color = Color.FromHex("AB9FACE6");
                FirstColor.Offset = (float)0.1;
                SecondColor.Offset = (float)1.0;
                br.GradientStops.Add(FirstColor);
                br.GradientStops.Add(SecondColor);
                BG.Background = br;

                LinearGradientBrush ButtonBrush = new LinearGradientBrush();
                ButtonBrush.StartPoint = new Point(1, 0);
                ButtonBrush.EndPoint = new Point(0, 1);
                GradientStop FirstButtonColor = new GradientStop();
                GradientStop SecondButtonColor = new GradientStop();
                FirstButtonColor.Color = Color.FromHex("AB74EBD5");
                SecondButtonColor.Color = Color.FromHex("AB9FACE6");
                FirstButtonColor.Offset = (float)0.1;
                SecondButtonColor.Offset = (float)1.0;
                ButtonBrush.GradientStops.Add(FirstButtonColor);
                ButtonBrush.GradientStops.Add(SecondButtonColor);
                Back.Background = ButtonBrush;
                Forward.Background = ButtonBrush;
            }
            else
            {
                LinearGradientBrush br = new LinearGradientBrush();
                br.StartPoint = new Point(1, 0);
                br.EndPoint = new Point(0, 1);
                GradientStop FirstColor = new GradientStop();
                GradientStop SecondColor = new GradientStop();
                FirstColor.Color = Color.FromHex("ABF68084");
                SecondColor.Color = Color.FromHex("ABA6C0FE");
                FirstColor.Offset = (float)0.1;
                SecondColor.Offset = (float)1.0;
                br.GradientStops.Add(FirstColor);
                br.GradientStops.Add(SecondColor);
                BG.Background = br;


            }

            HeightImage.Source = ImageSource.FromResource("DietManager.wheight.png");
            Back.ImageSource = ImageSource.FromResource("DietManager.smb.png");
            Forward.ImageSource = ImageSource.FromResource("DietManager.smf.png");

        }


        protected async void HeightClick(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(HeightEntry.Text))
            {
                await DisplayAlert("Значение роста", "Пожалуйста, укажите значение от 100 до 250 см", "ОК");
                return;
            }
            else
            {
                int height = int.Parse(HeightEntry.Text);
                if (height < 100 || height > 250)
                {
                    await DisplayAlert("Значение роста", "Пожалуйста, укажите значение от 100 до 250 см", "ОК");
                    return;
                }
                else
                {
                    await Navigation.PushAsync(new ParameterPage(gender, height));
                }
            }
        }

        protected async void HeightBackClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Gender());

        }

    }
}