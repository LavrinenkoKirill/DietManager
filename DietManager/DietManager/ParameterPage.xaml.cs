using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DietManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ParameterPage : ContentPage
    {
        private string gender;
        private int height;
        public ParameterPage(string gender, int height)
        {
            InitializeComponent();
            this.gender = gender;
            this.height = height;
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
                HeightBG.Background = br;

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
                ParameterBack.Background = ButtonBrush;
                ParameterForward.Background = ButtonBrush;
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
                HeightBG.Background = br;


            }


        }

        protected async void ParameterClick(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(WeightEntry.Text))
            {
                await DisplayAlert("Значение текущего веса", "Пожалуйста, укажите значение от 41 до 150 кг", "ОК");
                return;
            }

            else if (string.IsNullOrEmpty(NeedEntry.Text))
            {
                await DisplayAlert("Значение желаемого веса", "Пожалуйста, укажите значение от 40 до 149 кг", "ОК");
                return;
            }

            else if (string.IsNullOrEmpty(TermEntry.Text))
            {
                await DisplayAlert("Значение длительности программы", "Пожалуйста, укажите значение от 2 недель", "ОК");
                return;
            }

            else
            {
                int currentWeight = int.Parse(WeightEntry.Text);
                if (currentWeight < 41 || currentWeight > 150)
                {
                    await DisplayAlert("Значение текущего веса", "Пожалуйста, укажите значение от 41 до 150 кг", "ОК");
                    return;
                }
                else 
                {
                    int wishWeight = int.Parse(NeedEntry.Text);
                    if (wishWeight < 41 || wishWeight > 149)
                    {
                        await DisplayAlert("Значение желаемого веса", "Пожалуйста, укажите значение от 40 до 149 кг", "ОК");
                        return;
                    }

                    else
                    {
                        int term = int.Parse(TermEntry.Text);
                        if (term < 2)
                        {
                            await DisplayAlert("Значение желаемого веса", "Пожалуйста, укажите значение от 40 до 149 кг", "ОК");
                            return;
                        }

                        else
                        {
                            await Navigation.PushAsync(new SuccessPage(gender, height, currentWeight, wishWeight, term));
                        }
                    }
                }
            }
        }
    }
}