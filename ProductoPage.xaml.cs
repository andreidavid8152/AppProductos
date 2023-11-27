using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;
using System.Threading;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Collections.ObjectModel;
using MauiApp1.Models;
using MauiApp1.Service;

namespace MauiApp1;

public partial class ProductoPage : ContentPage
{
    private readonly APIService _api;
    public ProductoPage(APIService api)
    {
        InitializeComponent();
        _api = api;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        var productos = await _api.GetProductos();
        listaProductos.ItemsSource = productos;
    }

    private async void OnClickNuevoProducto(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NuevoProducto(_api));
    }

    private async void onClickShowDetails(object sender, SelectedItemChangedEventArgs e)
    {
        Producto producto = e.SelectedItem as Producto;
        await Navigation.PushAsync(new DetailsProducto(_api)
        {
            BindingContext = producto,
        });

    }
}