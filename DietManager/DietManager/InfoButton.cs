using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DietManager
{
    public class InfoButton : Button
    {
        private string product;
        private double caloriesValue;

        public void setProduct(string product) { this.product = product; }
        public void setCaloriesValue(int caloriesValue) { this.caloriesValue = caloriesValue;}

        public string getProduct() { return product; }
        public double getCaloriesValue() {  return caloriesValue; }
    }
}
