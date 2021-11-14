using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyFirstApp.Models;

namespace MyFirstApp.Views
{ 
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoffeEquipmentPage : ContentPage
    {
        public CoffeEquipmentPage()
        {
            InitializeComponent();
            // BindingContext = this;
            // LabelCount.Text = "Hello from code behind";
            // ButtonClick.Clicked += ButtonClick_Clicked; 
        }

        /* We MVVMfied these events in ViewModels.CoffeeEquipmentViewModel.cs file
        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var coffee = ((ListView)sender).SelectedItem as Coffee;
            if (coffee == null)
                return;

            await DisplayAlert("Coffee Selected", coffee.Name, "Ok");

        }
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            

        }
        */

        // We will make an asyncCommand for this MenuItem to MVVMply
        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var coffee = ((MenuItem)sender).BindingContext as Coffee;
            if (coffee == null)
                return;

            await DisplayAlert("Coffee Favourited", coffee.Name, "Ok");

        }


    }
}