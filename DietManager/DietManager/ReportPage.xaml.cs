﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DietManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportPage : ContentPage
    {
        private string gender;
        private int currentWeight;
        private int wishWeight;
        private int day;
        private double dailyRate;
        private double dailyBurn;


        public ReportPage(string gender, int currentWeight, int wishWeight, int day, double dailyRate)
        {
            this.gender = gender;
            this.currentWeight = currentWeight;
            this.wishWeight = wishWeight;
            this.day = day;
            this.dailyRate = dailyRate;
            double normalRate;
            if (currentWeight > wishWeight)
            {
                normalRate = dailyRate * 1.2;
                dailyBurn = (normalRate - dailyRate) / 6.15;
                dailyBurn /= 1000;

            }
            else if (currentWeight < wishWeight)
            {
                normalRate = dailyRate * 0.8;
                dailyBurn = (dailyRate - normalRate) / 6.15;
                dailyBurn /= 1000;
            }
            else
            {
                dailyBurn = 0;
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
                FirstColor.Color = Color.FromHex("AB9FACE6");
                SecondColor.Color = Color.FromHex("AB74EBD5");
                FirstColor.Offset = (float)0.1;
                SecondColor.Offset = (float)1.0;
                br.GradientStops.Add(FirstColor);
                br.GradientStops.Add(SecondColor);
                ReportBG.Background = br;


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
                PButton.Background = PlanButtonBrush;

                Frame1.BackgroundColor = Color.FromHex("3f63998f");
                Frame2.BackgroundColor = Color.FromHex("3f63998f");
                Frame3.BackgroundColor = Color.FromHex("3f63998f");
                Frame4.BackgroundColor = Color.FromHex("3f63998f");


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
                ReportBG.Background = br;


            }
            completedDaysLabel.Text = (day - 1).ToString();
            completedDaysLabel.FontSize = 20;

            if (currentWeight > wishWeight) remainingDaysLabel.Text = ((int)((currentWeight - wishWeight) / dailyBurn - day)).ToString();
            else remainingDaysLabel.Text = ((int)((wishWeight - currentWeight) / dailyBurn - day)).ToString();

            remainingDaysLabel.FontSize = 20;

            if (currentWeight < wishWeight) burnOrGetLabel.Text = "Набрано";
            else burnOrGetLabel.Text = "Сожжено";

            burnLabel.Text = (Math.Round(dailyBurn * (day - 1),2)).ToString();
            burnLabel.FontSize = 20;

            if (currentWeight > wishWeight) weightLabel.Text = Math.Round((currentWeight - (day - 1) * dailyBurn),2).ToString();
            else weightLabel.Text = Math.Round((currentWeight + (day - 1) * dailyBurn),2).ToString();

            weightLabel.FontSize = 20;

        }

        protected async void PClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlanPage());
        }


    }
}