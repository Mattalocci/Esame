using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static System.Net.WebRequestMethods;

namespace Esame
{
    public partial class MainPage : ContentPage
    {
        RestService service;
        public ObservableCollection<Product> Products { get; set; } = new();
        public MainPage()
        {
            InitializeComponent();
            service = new RestService();

            BindingContext = this;
           

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadProducts();
        }

        private async Task LoadProducts()
        {
            var list = await service.GetProductsAsync();

            Products.Clear();
            foreach (var item in list)
                Products.Add(item);
        }

        
        private async void OnButtonClicked(object sender, EventArgs e)
        {
            var service = new RestService();
            var product = await service.GetProductsAsync();
        }

        private async void OnSelectionChanged(object sender, EventArgs e)
        {


        }
    }
}

