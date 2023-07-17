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
        private int caloriesTotal = 0;

        public void setProduct(string product) { this.product = product; }
        public void setCaloriesValue(int caloriesValue) { this.caloriesValue = caloriesValue;}

        public void setCaloriesTotal(int caloriesTotal) { this.caloriesTotal = caloriesTotal;}

        public string getProduct() { return product; }
        public double getCaloriesValue() {  return caloriesValue; }

        public int getCaloriesTotal() {  return caloriesTotal; }
    }
}
