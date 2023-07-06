using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DietManager
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Gender : ContentPage
	{
		public Gender ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            Male.Source = ImageSource.FromResource("DietManager.male.png");
            Female.Source = ImageSource.FromResource("DietManager.female.png");
        }

        protected async void GenderClick(object sender, EventArgs e)
        {
            string gender;
            if (MaleButton.IsChecked) gender = "Male";
            else if (FemaleButton.IsChecked) gender = "Female";
            else return;
            await Navigation.PushAsync(new HeightPage(gender));
        }
    }
}