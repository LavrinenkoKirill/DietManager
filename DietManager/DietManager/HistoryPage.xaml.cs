using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace DietManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        private string gender;
        private int calories;
        public HistoryPage(string gender, int calories)
        {
            this.gender = gender;
            this.calories = calories;
            InitializeComponent();
        }

        protected LinearGradientBrush PaintByGender(string gender)
        {
            if (gender == "Male")
            {
                LinearGradientBrush ButtonBrush = new LinearGradientBrush();
                ButtonBrush.StartPoint = new Point(1, 0);
                ButtonBrush.EndPoint = new Point(0, 1);
                GradientStop FirstButtonColor = new GradientStop();
                GradientStop SecondButtonColor = new GradientStop();
                FirstButtonColor.Color = Color.FromHex("AB9FACE6");
                SecondButtonColor.Color = Color.FromHex("AB9FACE6");
                FirstButtonColor.Offset = (float)0.1;
                SecondButtonColor.Offset = (float)1.0;
                ButtonBrush.GradientStops.Add(FirstButtonColor);
                ButtonBrush.GradientStops.Add(SecondButtonColor);
                return ButtonBrush;
            }
            else
            {
                LinearGradientBrush ButtonBrush = new LinearGradientBrush();
                ButtonBrush.StartPoint = new Point(1, 0);
                ButtonBrush.EndPoint = new Point(0, 1);
                GradientStop FirstButtonColor = new GradientStop();
                GradientStop SecondButtonColor = new GradientStop();
                FirstButtonColor.Color = Color.FromHex("FF9A9E");
                SecondButtonColor.Color = Color.FromHex("#FFB5E7");
                FirstButtonColor.Offset = (float)0.1;
                SecondButtonColor.Offset = (float)1.0;
                ButtonBrush.GradientStops.Add(FirstButtonColor);
                ButtonBrush.GradientStops.Add(SecondButtonColor);
                return ButtonBrush;
            }
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
                FirstColor.Color = Color.FromHex("AB9FACE6");
                SecondColor.Color = Color.FromHex("AB74EBD5");
                FirstColor.Offset = (float)0.1;
                SecondColor.Offset = (float)1.0;
                br.GradientStops.Add(FirstColor);
                br.GradientStops.Add(SecondColor);
                HistoryBG.Background = br;

                Frame1.BackgroundColor = Color.FromHex("3f63998f");
                Frame2.BackgroundColor = Color.FromHex("3f63998f");


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
                HistoryBG.Background = br;


            }

            string localHistoryPath = Path.Combine(FileSystem.CacheDirectory, "History.txt");
            if (File.Exists(localHistoryPath))
            {
                string parameters = File.ReadAllText(localHistoryPath);
                Debug.WriteLine(parameters);
                string[] pars = parameters.Split('\n');
                for (int i = 0; i < pars.Length - 1; i++)
                {
                    string[] info = pars[i].Split(' ');
                    Debug.WriteLine(info[0]);
                    Frame prod = new Frame();
                    prod.HeightRequest = 18;
                    prod.WidthRequest = 270;
                    prod.Margin = new Thickness(50, 10, 50, 0);
                    prod.BackgroundColor = Color.White;
                    prod.CornerRadius = 20;
                    Label label = new Label();
                    label.Text = info[0] + ", " + info[1] + ' ' + "грамм";
                    label.TextColor = Color.Black;
                    prod.Content = label;
                    HistoryBG.Children.Add(prod);

                }
            }

            Button AddButton = new Button();
            AddButton.HeightRequest = 60;
            AddButton.BorderColor = Color.Gray;
            AddButton.WidthRequest = 50;
            AddButton.BorderWidth = 1;
            AddButton.Text = "Добавить";
            AddButton.TextColor = Color.White;
            AddButton.Margin = new Thickness(100, 50, 100, 0);
            AddButton.CornerRadius = 20;
            AddButton.Clicked += AddButtonClick;
            AddButton.Background = PaintByGender(gender);
            HistoryBG.Children.Add(AddButton);

            caloriesRemainsLabel.Text = calories.ToString();
            

        }

        protected async void AddButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CategoryPage(gender,calories));
        }
    }
}