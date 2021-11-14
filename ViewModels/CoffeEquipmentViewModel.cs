using System;
using System.Linq;
using System.Collections.ObjectModel;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyFirstApp.Models;
using Xamarin.Forms;

namespace MyFirstApp.ViewModels
{
    public class CoffeEquipmentViewModel : ViewModelBasecs
    {
        // ObservableRangeCollenctions is from MVVM Helpers, used to add delete and ranges the different data
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public ObservableRangeCollection<Grouping<string, Coffee>> CoffeeGroups { get; }
        // This will pull data down from the internet
        public AsyncCommand RefreshCommand { get; }
        public Coffee previousSelected;
        public Coffee selectedCoffee;
        public AsyncCommand<Coffee> FavouriteCommand { get; }
        public AsyncCommand<object> SelectedCommand { get; }
        public Xamarin.Forms.Command LoadMoreCommand { get; }
        public Xamarin.Forms.Command DelayLoadMoreCommand { get; }
        public Xamarin.Forms.Command ClearCommand { get; }



        // Constructor 
        public CoffeEquipmentViewModel()
        {
            Title = "Coffee Equipment";

            // Linq has been used for ObservableRange COLLECTION
            Coffee = new ObservableRangeCollection<Coffee>();
            CoffeeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();

            var image = "https://www.yesplz.coffee/app/uploads/2020/11/Mug9.png";

            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Sip of Sunshine", Image = "https://beveragewarehousevt.com/home/wp-content/uploads/2016/03/lawsons-coffee-fayston-maple-imperial-stout-622x372.jpeg" });
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Potent Potable", Image = "https://img.proidee.de/pimg/1300/22/1300_229447b_0819.jpg" });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu", Image = "https://c.roastmarket.de/media//catalog/product/w/i/wildkaffee-kenia-riakahara-250g.jpg" });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu", Image = "https://c.roastmarket.de/media//catalog/product/w/i/wildkaffee-kenia-riakahara-250g.jpg" });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu", Image = "https://c.roastmarket.de/media//catalog/product/w/i/wildkaffee-kenia-riakahara-250g.jpg" });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu", Image = "https://c.roastmarket.de/media//catalog/product/w/i/wildkaffee-kenia-riakahara-250g.jpg" });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu", Image = "https://c.roastmarket.de/media//catalog/product/w/i/wildkaffee-kenia-riakahara-250g.jpg" });

            CoffeeGroups.Add(new Grouping<string, Coffee>("Blue Bottle", new[] {Coffee[2] }));
            //Take() to get only the first 2 elements of the collection
            CoffeeGroups.Add(new Grouping<string, Coffee>("Yes Plz", Coffee.Take(2)));

            RefreshCommand = new AsyncCommand(Refresh);
            FavouriteCommand = new AsyncCommand<Coffee>(Favourite);
            SelectedCommand = new AsyncCommand<object>(Selected);

            // Command Class accepts only functions as parameters
            /*IncreaseCount = new Command(OnIncrease);
            CallServerCommand = new AsyncCommand(CallServer);
            Coffee = new ObservableRangeCollection<string>();
            */
        }

        async Task Favourite(Coffee coffee)
        {
            if (coffee == null)
                return;
            await Application.Current.MainPage.DisplayAlert("Favourite", coffee.Name, "Ok");
        }

        async Task Selected(object args)
        {
            var coffee = args as Coffee;
            if (coffee == null)
                return;
            // We are doing twoWay data binding, and deselecting the item before the Pop-up
            SelectedCoffee = null;
            await Application.Current.MainPage.DisplayAlert("Selected", coffee.Name, "Ok");
        }

        public Coffee SelectedCoffee
        {
            get => selectedCoffee;
            set => SetProperty(ref selectedCoffee, value);
            
            /*{
                if(value != null)
                {
                    // Now the DisplayAlert event is a Async so we have to await but this a
                    // property so we need to convert event into the command 
                    Application.Current.MainPage.DisplayAlert("Selected", value.Name, "Ok");
                    previousSelected = value;
                    value = null;
                }

                selectedCoffee = value;
                OnPropertyChanged();
            }*/

        }

        async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            IsBusy = false;
        }


        /*
        public ICommand CallServerCommand { get; }

        //This is a Async Task which is not a function (action)
        async Task CallServer()
        {
            // It sends each the notifcation when the element is added to list 
            // Thats why we use ObservableRANGECollection
            var items = new List<string> { "Yes Plz", "Tonx", "Bottel Bottel" };
            Coffee.AddRange(items);
        }

        public ICommand IncreaseCount { get; }

        int count = 0;
        string countDisplay = "Click Me!";
        public string CountDisplay
        {
            get => countDisplay;
            set => SetProperty(ref countDisplay, value);
            /*set
            {
                if (value == countDisplay)
                    return;
                countDisplay = value;
                // put the BindingContext = this. for xamarin.forms
                OnPropertyChanged();

            }*/ /*

        }
        void OnIncrease()
        {
            count++;
            CountDisplay = $"You Clicked {count} time(s)";
        }
        */
    }
}
