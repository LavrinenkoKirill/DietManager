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
    public partial class CategoryPage : ContentPage
    {
        private string gender;
        private int calories;
        public CategoryPage(string gender, int calories)
        {
            InitializeComponent();
            this.gender = gender;
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
                CategoryBG.Background = br;

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
                Home.Background = ButtonBrush;



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
                CategoryBG.Background = br;


            }

            Back.ImageSource = ImageSource.FromResource("DietManager.smb.png");
            Home.ImageSource = ImageSource.FromResource("DietManager.home.png");
            MilkButton.ImageSource = ImageSource.FromResource("DietManager.smilk.png");
            MeatButton.ImageSource = ImageSource.FromResource("DietManager.meat.png");
            FishButton.ImageSource = ImageSource.FromResource("DietManager.fish.png");
            FruitButton.ImageSource = ImageSource.FromResource("DietManager.fruit.png");
            VegetableButton.ImageSource = ImageSource.FromResource("DietManager.veg.png");
            BreadButton.ImageSource = ImageSource.FromResource("DietManager.bread.png");
            DrinkButton.ImageSource = ImageSource.FromResource("DietManager.drink.png");

        }

        protected async void BackClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryPage(gender, calories));

        }

        protected async void HomeClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlanPage());

        }

        protected async void CategoryMilkClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChooseProductPage(gender,"Молочные продукты",calories));

        }

        protected async void CategoryMeatClick(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ChooseProductPage(gender, "Мясные продукты", calories));
        }

        protected async void CategoryFishClick(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ChooseProductPage(gender, "Рыбные продукты", calories));
        }

        protected async void CategoryFruitClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChooseProductPage(gender, "Фрукты", calories));

        }
        protected async void CategoryVegClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChooseProductPage(gender, "Овощи", calories));

        }
        protected async void CategoryBreadClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChooseProductPage(gender, "Хлебные изделия", calories));

        }
        protected async void CategoryDrinkClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChooseProductPage(gender, "Напитки", calories));

        }
    }
}