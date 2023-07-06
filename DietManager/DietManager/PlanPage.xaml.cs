using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
        private int term;
        public PlanPage (string gender,int height, int currentWeight, int wishWeight, int term)
		{
            this.gender = gender;
            this.height = height;
            this.currentWeight = currentWeight;
            this.wishWeight = wishWeight;
            this.term = term;
            InitializeComponent ();
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

                LinearGradientBrush PlanButtonBrush = new LinearGradientBrush();
                PlanButtonBrush.StartPoint = new Point(1, 0);
                PlanButtonBrush.EndPoint = new Point(0, 1);
                GradientStop FirstPlanButtonColor = new GradientStop();
                GradientStop SecondPlanButtonColor = new GradientStop();
                FirstPlanButtonColor.Color = Color.FromHex("E0C3FC");
                SecondPlanButtonColor.Color = Color.FromHex("8EC5FC");
                FirstPlanButtonColor.Offset = (float)0.1;
                SecondPlanButtonColor.Offset = (float)1.0;
                PlanButtonBrush.GradientStops.Add(FirstButtonColor);
                PlanButtonBrush.GradientStops.Add(SecondButtonColor);
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


        }


    }
}