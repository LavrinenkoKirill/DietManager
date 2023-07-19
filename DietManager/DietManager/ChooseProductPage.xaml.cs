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

        protected void GetProducts(string path)
        {
            string products = File.ReadAllText(path);
            string[] pars = products.Split('\n');
            for (int i = 0; i < pars.Length; i++)
            {
                string[] info = pars[i].Split(' ');
                Frame prod = new Frame();
                prod.HeightRequest = 18;
                prod.WidthRequest = 270;
                prod.Margin = new Thickness(10, 0, 0, 0);
                prod.BackgroundColor = Color.White;
                prod.CornerRadius = 20;
                Label label = new Label();
                label.Text = info[0] + ", " + info[1] + ' ' + "калорий на 100 грамм";
                label.TextColor = Color.Black;
                prod.Content = label;
                InfoButton button = new InfoButton();
                button.WidthRequest = 50;
                button.Margin = new Thickness(10, 0, 20, 0);
                button.setProduct(info[0]);
                button.setCaloriesValue(int.Parse(info[1]));
                StackLayout stack = new StackLayout();
                stack.Spacing = 20;
                stack.Orientation = StackOrientation.Horizontal;
                stack.Children.Add(prod);
                stack.Children.Add(button);
                button.HeightRequest = 15;
                button.ImageSource = ImageSource.FromResource("DietManager.images.plus7.png");
                button.Clicked += AddClick;
                ChooseProductBG.Children.Add(stack);

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

                Frame1.BackgroundColor = Color.FromHex("3f63998f");


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

            string localPath;

            if (category == "Молочные продукты") localPath = Path.Combine(FileSystem.CacheDirectory, "MilkProducts.txt");
            else if (category == "Мясные продукты") localPath = Path.Combine(FileSystem.CacheDirectory, "MeatProducts.txt");
            else if (category == "Рыбные продукты") localPath = Path.Combine(FileSystem.CacheDirectory, "FishProducts.txt");
            else if (category == "Фрукты") localPath = Path.Combine(FileSystem.CacheDirectory, "FruitProducts.txt");
            else if (category == "Овощи") localPath = Path.Combine(FileSystem.CacheDirectory, "VegetableProducts.txt");
            else if (category == "Хлебные изделия") localPath = Path.Combine(FileSystem.CacheDirectory, "BreadProducts.txt");
            else localPath = Path.Combine(FileSystem.CacheDirectory, "DrinkProducts.txt");

            GetProducts(localPath);
      
        }

        protected async void BackClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CategoryPage(gender, calories));

        }

        protected async void HomeClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());

        }

        protected async void AddClick(object sender, EventArgs e)
        {
            InfoButton infoButton = (InfoButton)sender;
            string result = await DisplayPromptAsync("Вес продукта", "Пожалуйста, укажите вес продукта в граммах", "ОК", "Отмена", "Введите количество грамм" , -1, Keyboard.Numeric);
            if (result != null) 
            {
                try
                {
                    int gram = int.Parse(result);


                    if (gram < 1 || gram > 1000000)
                    {
                        await DisplayAlert("Некорректный вес", "Пожалуйста, укажите положительный вес продукта", "Ок");
                        return;
                    }
                    else
                    {

                        string localHistoryPath = Path.Combine(FileSystem.CacheDirectory, "History.txt");
                        File.AppendAllText(localHistoryPath, infoButton.getProduct() + ' ' + gram.ToString() + ' ' + ((int)((infoButton.getCaloriesValue() / 100) * gram)).ToString() + '\n');
                        string localCaloriesPath = Path.Combine(FileSystem.CacheDirectory, "Calories.txt");
                        string prevCal = File.ReadAllText(localCaloriesPath);
                        int prev = int.Parse(prevCal);
                        prev += (int)((infoButton.getCaloriesValue() / 100) * gram);
                        File.WriteAllText(localCaloriesPath, prev.ToString());
                        var answer = DisplayAlert("Отлично", "Продукт успешно добавлен", "ОК");
                        if (answer != null) { await Navigation.PushAsync(new PlanPage()); }

                    }
                }

                catch (FormatException)
                {
                    await DisplayAlert("Внимание", "Вы ввели некорректное значение количества грамм", "ОК");
                    return;
                }
                catch (OverflowException)
                {
                    await DisplayAlert("Внимание", "Вы ввели некорректное значение количества грамм", "ОК");
                    return;
                }
            }
            
        }

    }
}