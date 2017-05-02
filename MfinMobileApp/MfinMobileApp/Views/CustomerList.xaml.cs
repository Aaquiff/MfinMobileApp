using MfinMobileApp.Controllers;
using MfinMobileApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MfinMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerList : ContentPage
    {
       

        public CustomerList()
        {
            InitializeComponent();
            BindingContext = new CustomerListViewModel();
        }

        protected async override void OnAppearing()
        {
            CustomerController cc = new CustomerController();
            List<Customer> Items = new List<Customer>();
            try
            {
                customerList.ItemsSource = await cc.GetCustomersRest();
            }
            catch (Exception ex)
            {
                await DisplayAlert(ex.Message,ex.InnerException.Message,"OK");
            }

            base.OnAppearing();

        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
            => ((ListView)sender).SelectedItem = null;

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            //await DisplayAlert("Selected", e.SelectedItem.ToString(), "OK");
            Customer customer = (Customer)e.SelectedItem;
            await Navigation.PushAsync(new CustomerDetail(customer));
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }



    class CustomerListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Customer> Items { get; }
        public ObservableCollection<Grouping<string, Customer>> ItemsGrouped { get; }

        public CustomerListViewModel()
        {

            CustomerController cc = new CustomerController();
            /*Items = cc.GetCustomersRest();

            var sorted = from item in Items
                         orderby item.id
                         group item by item.name[0].ToString() into itemGroup
                         select new Grouping<string, Customer>(itemGroup.Key, itemGroup);

            ItemsGrouped = new ObservableCollection<Grouping<string, Customer>>(sorted);

            RefreshDataCommand = new Command(
                async () => await RefreshData());*/
        }

        public ICommand RefreshDataCommand { get; }

        async Task RefreshData()
        {
            IsBusy = true;
            //Load Data Here
            await Task.Delay(2000);

            IsBusy = false;
        }

        bool busy;
        public bool IsBusy
        {
            get { return busy; }
            set
            {
                busy = value;
                OnPropertyChanged();
                ((Command)RefreshDataCommand).ChangeCanExecute();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public class Grouping<K, T> : ObservableCollection<T>
        {
            public K Key { get; private set; }

            public Grouping(K key, IEnumerable<T> items)
            {
                Key = key;
                foreach (var item in items)
                    this.Items.Add(item);
            }
        }
    }
}
