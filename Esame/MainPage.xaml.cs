using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Esame
{
    public partial class MainPage : ContentPage
    {
        RestService service;
        public ObservableCollection<Product> Items { get; set; } = new();
        public MainPage()
        {
            InitializeComponent();
            service = new RestService();

            BindingContext = this;
           

        }

        protected async override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            var products = await service.GetProductsAsync();
            foreach (var p in products)
            {
                Items.Add(p);
            }
        }

        private async void ProductsCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is not Product item)
                return;
            await Shell.Current.GoToAsync(nameof(ProductPage), true, new Dictionary<string, object>
            {
                ["Item"] = item
            });
        }
        
        private async void OnButtonClicked(object sender, EventArgs e)
        {
            var service = new RestService();
            var product = await service.GetProductsAsync();
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is not Product item)
                return;

            await Shell.Current.GoToAsync(nameof(ProductPage), true, new Dictionary<string, object>
            {
                ["Item"] = item
            });

        }
    }
}

