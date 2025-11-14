namespace Esame;

[QueryProperty("Item", "Item")]
public partial class ProductPage : ContentPage 
{

    public ProductPage Item
    {
        get => BindingContext as ProductPage;
        set => BindingContext = value;
    }
    public ProductPage()
	{
        InitializeComponent();

    }

    private async void OnItemAdded(object sender, EventArgs e)
    {


    }
}