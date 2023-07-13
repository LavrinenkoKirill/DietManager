using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DietManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlanPage : ContentPage
    {
        private string gender;
        private int height;
        private int currentWeight;
        private int wishWeight;
        private int age;
        private int day;
        private double dailyRate;
        private int caloryToday;
        const string localFileName = "Parameters.txt";
        const string localFileDayName = "Day.txt";
        string localDayPath;
        public PlanPage()
        {
            string localPath = Path.Combine(FileSystem.CacheDirectory, localFileName);
            localDayPath = Path.Combine(FileSystem.CacheDirectory, localFileDayName);
            if (File.Exists(localPath))
            {
                string parameters = File.ReadAllText(localPath);
                string[] pars = parameters.Split('\n');
                gender = pars[0];
                height = int.Parse(pars[1]);
                currentWeight = int.Parse(pars[2]);
                wishWeight = int.Parse(pars[3]);
                age = int.Parse(pars[4]);
                string strDay = File.ReadAllText(localDayPath);
                day = int.Parse(strDay);

                if (gender == "Male")
                {
                    dailyRate = (88.362 + (13.397 * currentWeight) + (4.799 * this.height) - (5.677 * this.age)) * 1.2;
                    if (currentWeight > wishWeight)
                    {
                        dailyRate *= 0.8;
                    }
                    else if (currentWeight < wishWeight)
                    {
                        dailyRate *= 1.2;
                    }

                }
                else
                {
                    dailyRate = (447.593 + (9.247 * currentWeight) + (3.098 * this.height) - (4.33 * this.age)) * 1.2;
                    if (currentWeight > wishWeight)
                    {
                        dailyRate *= 0.8;
                    }
                    else if (currentWeight < wishWeight)
                    {
                        dailyRate *= 1.2;
                    }
                }
                caloryToday = 0;

            }
            else
            {
                Console.Write("File does not exist");
            }
            InitializeComponent();
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
                PlanBG.Background = br;

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
                HistoryButton.Background = ButtonBrush;
                SaveButton.Background = ButtonBrush;

                LinearGradientBrush PlanButtonBrush = new LinearGradientBrush();
                PlanButtonBrush.StartPoint = new Point(1, 0);
                PlanButtonBrush.EndPoint = new Point(0, 1);
                GradientStop FirstPlanButtonColor = new GradientStop();
                GradientStop SecondPlanButtonColor = new GradientStop();
                FirstPlanButtonColor.Color = Color.FromHex("E0C3FC");
                SecondPlanButtonColor.Color = Color.FromHex("8EC5FC");
                FirstPlanButtonColor.Offset = (float)0.1;
                SecondPlanButtonColor.Offset = (float)1.0;
                PlanButtonBrush.GradientStops.Add(FirstPlanButtonColor);
                PlanButtonBrush.GradientStops.Add(SecondPlanButtonColor);
                PlanButton.Background = PlanButtonBrush;



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
                PlanBG.Background = br;


            }

            dailyRateLabel.Text = ((int)dailyRate).ToString();
            caloryTodayLabel.Text = ((int)caloryToday).ToString();
            DayLabel.Text = "День " + day.ToString();

        }

        protected async void ReportClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReportPage(gender, currentWeight, wishWeight, day, dailyRate));
        }

        protected async void SaveDayClick(object sender, EventArgs e)
        {
            File.WriteAllText(localDayPath, (day + 1).ToString());
            await Navigation.PushAsync(new PlanPage());
        }

        protected async void HistoryClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryPage(gender,(int)dailyRate - caloryToday));
        }


    }
}