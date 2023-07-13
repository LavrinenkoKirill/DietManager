using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DietManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseProductPage : ContentPage
    {
        private string gender;
        private string category;
        private int calories;
        public ChooseProductPage(string gender, string category, int calories)
        {
            InitializeComponent();
            this.gender = gender;
            this.category = category;
            this.calories = calories;
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
                ChooseProductBG.Background = br;

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
               // Back.Background = ButtonBrush;
               // Home.Background = ButtonBrush;



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
                ChooseProductBG.Background = br;


            }

           // Back.ImageSource = ImageSource.FromResource("DietManager.smb.png");
           // Home.ImageSource = ImageSource.FromResource("DietManager.home.png");
            CategoryNameLabel.Text = category;


            if (category == "Молочные продукты") 
            {
                string localMilkPath = Path.Combine(FileSystem.CacheDirectory, "MilkProducts.txt");
                string products = File.ReadAllText(localMilkPath);
                string[] pars = products.Split('\n');
                for (int i = 0; i < pars.Length; i++)
                {
                    string[] info = pars[i].Split(' ');
                    Frame prod = new Frame();
                    prod.Margin = new Thickness(10, 0, 0, 0);
                    prod.BackgroundColor = Color.White;
                    prod.CornerRadius = 20;
                    Label label = new Label();
                    label.Text = info[0] + ", " + info[1] + ' ' + "калорий на 100 грамм";
                    label.TextColor = Color.Black;
                    prod.Content = label;
                    Button button = new Button();
                    button.HeightRequest = 10;
                    button.WidthRequest = 30;
                    button.Margin = new Thickness(0, 0, 20, 0);
                    button.ImageSource = ImageSource.FromResource("DietManager.plus.png");
                    StackLayout stack = new StackLayout();
                    stack.Spacing = 20;
                    stack.Orientation = StackOrientation.Horizontal;
                    stack.Children.Add(prod);
                    stack.Children.Add(button);
                    ChooseProductBG.Children.Add(stack);

                }
            }

            if (category == "Мясные продукты")
            {
                string localMeatPath = Path.Combine(FileSystem.CacheDirectory, "MeatProducts.txt");
                string products = File.ReadAllText(localMeatPath);
                string[] pars = products.Split('\n');
                for (int i = 0; i < pars.Length; i++)
                {
                    string[] info = pars[i].Split(' ');
                    Frame prod = new Frame();
                    prod.Margin = new Thickness(10, 0, 0, 0);
                    prod.BackgroundColor = Color.White;
                    prod.CornerRadius = 20;
                    Label label = new Label();
                    label.Text = info[0] + ", " + info[1] + ' ' + "калорий на 100 грамм";
                    label.TextColor = Color.Black;
                    prod.Content = label;
                    Button button = new Button();
                    button.HeightRequest = 10;
                    button.WidthRequest = 30;
                    button.Margin = new Thickness(0, 0, 20, 0);
                    button.ImageSource = ImageSource.FromResource("DietManager.plus.png");
                    StackLayout stack = new StackLayout();
                    stack.Spacing = 20;
                    stack.Orientation = StackOrientation.Horizontal;
                    stack.Children.Add(prod);
                    stack.Children.Add(button);
                    ChooseProductBG.Children.Add(stack);

                }
            }

            if (category == "Рыбные продукты")
            {
                string localFishPath = Path.Combine(FileSystem.CacheDirectory, "FishProducts.txt");
                string products = File.ReadAllText(localFishPath);
                string[] pars = products.Split('\n');
                for (int i = 0; i < pars.Length; i++)
                {
                    string[] info = pars[i].Split(' ');
                    Frame prod = new Frame();
                    prod.Margin = new Thickness(10, 0, 0, 0);
                    prod.BackgroundColor = Color.White;
                    prod.CornerRadius = 20;
                    Label label = new Label();
                    label.Text = info[0] + ", " + info[1] + ' ' + "калорий на 100 грамм";
                    label.TextColor = Color.Black;
                    prod.Content = label;
                    Button button = new Button();
                    button.HeightRequest = 10;
                    button.WidthRequest = 30;
                    button.Margin = new Thickness(0, 0, 20, 0);
                    button.ImageSource = ImageSource.FromResource("DietManager.plus.png");
                    StackLayout stack = new StackLayout();
                    stack.Spacing = 20;
                    stack.Orientation = StackOrientation.Horizontal;
                    stack.Children.Add(prod);
                    stack.Children.Add(button);
                    ChooseProductBG.Children.Add(stack);

                }
            }
            if (category == "Фрукты")
            {
                string localFruitPath = Path.Combine(FileSystem.CacheDirectory, "FruitProducts.txt");
                string products = File.ReadAllText(localFruitPath);
                string[] pars = products.Split('\n');
                for (int i = 0; i < pars.Length; i++)
                {
                    string[] info = pars[i].Split(' ');
                    Frame prod = new Frame();
                    prod.Margin = new Thickness(10, 0, 0, 0);
                    prod.BackgroundColor = Color.White;
                    prod.CornerRadius = 20;
                    Label label = new Label();
                    label.Text = info[0] + ", " + info[1] + ' ' + "калорий на 100 грамм";
                    label.TextColor = Color.Black;
                    prod.Content = label;
                    Button button = new Button();
                    button.HeightRequest = 10;
                    button.WidthRequest = 30;
                    button.Margin = new Thickness(0, 0, 20, 0);
                    button.ImageSource = ImageSource.FromResource("DietManager.plus.png");
                    StackLayout stack = new StackLayout();
                    stack.Spacing = 20;
                    stack.Orientation = StackOrientation.Horizontal;
                    stack.Children.Add(prod);
                    stack.Children.Add(button);
                    ChooseProductBG.Children.Add(stack);

                }
            }
            if (category == "Овощи")
            {
                string localVegPath = Path.Combine(FileSystem.CacheDirectory, "VegetableProducts.txt");
                string products = File.ReadAllText(localVegPath);
                string[] pars = products.Split('\n');
                for (int i = 0; i < pars.Length; i++)
                {
                    string[] info = pars[i].Split(' ');
                    Frame prod = new Frame();
                    prod.Margin = new Thickness(10, 0, 0, 0);
                    prod.BackgroundColor = Color.White;
                    prod.CornerRadius = 20;
                    Label label = new Label();
                    label.Text = info[0] + ", " + info[1] + ' ' + "калорий на 100 грамм";
                    label.TextColor = Color.Black;
                    prod.Content = label;
                    Button button = new Button();
                    button.HeightRequest = 10;
                    button.WidthRequest = 30;
                    button.Margin = new Thickness(0, 0, 20, 0);
                    button.ImageSource = ImageSource.FromResource("DietManager.plus.png");
                    StackLayout stack = new StackLayout();
                    stack.Spacing = 20;
                    stack.Orientation = StackOrientation.Horizontal;
                    stack.Children.Add(prod);
                    stack.Children.Add(button);
                    ChooseProductBG.Children.Add(stack);

                }
            }
            if (category == "Хлебные изделия")
            {
                string localBreadPath = Path.Combine(FileSystem.CacheDirectory, "BreadProducts.txt");
                string products = File.ReadAllText(localBreadPath);
                string[] pars = products.Split('\n');
                for (int i = 0; i < pars.Length; i++)
                {
                    string[] info = pars[i].Split(' ');
                    Frame prod = new Frame();
                    prod.Margin = new Thickness(10, 0, 0, 0);
                    prod.BackgroundColor = Color.White;
                    prod.CornerRadius = 20;
                    Label label = new Label();
                    label.Text = info[0] + ", " + info[1] + ' ' + "калорий на 100 грамм";
                    label.TextColor = Color.Black;
                    prod.Content = label;
                    Button button = new Button();
                    button.HeightRequest = 10;
                    button.WidthRequest = 30;
                    button.Margin = new Thickness(0, 0, 20, 0);
                    button.ImageSource = ImageSource.FromResource("DietManager.plus.png");
                    StackLayout stack = new StackLayout();
                    stack.Spacing = 20;
                    stack.Orientation = StackOrientation.Horizontal;
                    stack.Children.Add(prod);
                    stack.Children.Add(button);
                    ChooseProductBG.Children.Add(stack);

                }
            }
            if (category == "Напитки")
            {
                string localDrinkPath = Path.Combine(FileSystem.CacheDirectory, "DrinkProducts.txt");
                string products = File.ReadAllText(localDrinkPath);
                string[] pars = products.Split('\n');
                for (int i = 0; i < pars.Length; i++)
                {
                    string[] info = pars[i].Split(' ');
                    Frame prod = new Frame();
                    prod.Margin = new Thickness(10, 0, 0, 0);
                    prod.BackgroundColor = Color.White;
                    prod.CornerRadius = 20;
                    Label label = new Label();
                    label.Text = info[0] + ", " + info[1] + ' ' + "калорий на 100 грамм";
                    label.TextColor = Color.Black;
                    prod.Content = label;
                    Button button = new Button();
                    button.HeightRequest = 10;
                    button.WidthRequest = 30;
                    button.Margin = new Thickness(0, 0, 20, 0);
                    button.ImageSource = ImageSource.FromResource("DietManager.plus.png");
                    StackLayout stack = new StackLayout();
                    stack.Spacing = 20;
                    stack.Orientation = StackOrientation.Horizontal;
                    stack.Children.Add(prod);
                    stack.Children.Add(button);
                    ChooseProductBG.Children.Add(stack);

                }
            }



        }

        protected async void BackClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CategoryPage(gender, calories));

        }

        protected async void HomeClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlanPage());

        }

        protected async void AddClick(object sender, EventArgs e, string info0, string info1)
        {
            await Navigation.PushAsync(new PlanPage());

        }

    }
}