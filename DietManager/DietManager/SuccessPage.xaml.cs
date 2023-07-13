using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DietManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SuccessPage : ContentPage
    {
        private string gender;
        private int height;
        private int currentWeight;
        private int wishWeight;
        private int age;
        string localPath;
        string localDayPath;
        const string localFileName = "Parameters.txt";
        const string localFileDayName = "Day.txt";
        public SuccessPage(string gender, int height, int currentWeight, int wishWeight, int age)
        {
            this.gender = gender;
            this.height = height;
            this.currentWeight = currentWeight;
            this.wishWeight = wishWeight;
            this.age = age;
            localPath = Path.Combine(FileSystem.CacheDirectory, localFileName);
            localDayPath = Path.Combine(FileSystem.CacheDirectory, localFileDayName);
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            SuccessImage.Source = ImageSource.FromResource("DietManager.ps.png");

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
                SuccessBG.Background = br;

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
                StartProgramButton.Background = ButtonBrush;
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
                SuccessBG.Background = br;


            }



        }

        protected async void StartProgramClick(object sender, EventArgs e)
        {
            string parameters = gender + '\n' + height.ToString() + '\n' + currentWeight.ToString() + '\n' + wishWeight.ToString() + '\n' + age.ToString();
            File.WriteAllText(localPath, parameters);
            File.WriteAllText(localDayPath, "1");


            string localMilkPath = Path.Combine(FileSystem.CacheDirectory, "MilkProducts.txt");
            string localMeatPath = Path.Combine(FileSystem.CacheDirectory, "MeatProducts.txt");
            string localFishPath = Path.Combine(FileSystem.CacheDirectory, "FishProducts.txt");
            string localFruitPath = Path.Combine(FileSystem.CacheDirectory, "FruitProducts.txt");
            string localVegPath = Path.Combine(FileSystem.CacheDirectory,   "VegetableProducts.txt");
            string localBreadPath = Path.Combine(FileSystem.CacheDirectory, "BreadProducts.txt");
            string localDrinkPath = Path.Combine(FileSystem.CacheDirectory, "DrinkProducts.txt");

            string milk = "Молоко " + "70" + '\n' + "Сыр " + "363" + '\n' + "Масло " + "748";
            File.WriteAllText(localMilkPath, milk);

            string meat = "Курица " + "210" + '\n' + "Свинина " + "259" + '\n' + "Говядина " + "187";
            File.WriteAllText(localMeatPath, meat);

            string fish = "Лосось " + "142" + '\n' + "Окунь " + "145" + '\n' + "Сельдь " + "190";
            File.WriteAllText(localFishPath, fish);

            string fruit = "Банан " + "96" + '\n' + "Манго " + "67" + '\n' + "Яблоко " + "60";
            File.WriteAllText(localFruitPath, fruit);

            string veg = "Огурец " + "15" + '\n' + "Помидор " + "25" + '\n' + "Капуста " + "28";
            File.WriteAllText(localVegPath, veg);

            string bread = "Хлеб(белый) " + "250" + '\n' + "Хлеб(Черный) " + "201";
            File.WriteAllText(localBreadPath, bread);

            string drink = "Чай " + "140" + '\n' + "Кофе " + "280" + '\n' + "Сок(яблочный) " + "42";
            File.WriteAllText(localDrinkPath, drink);


            await Navigation.PushAsync(new PlanPage());

        }

    }
}