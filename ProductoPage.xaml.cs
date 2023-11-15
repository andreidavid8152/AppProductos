using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;
using System.Threading;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Collections.ObjectModel;
using MauiApp1.Models;

namespace MauiApp1;

public partial class ProductoPage : ContentPage
{
    public ProductoPage()
    {
        InitializeComponent();
        listaProductos.ItemsSource = Utils.Utils.ListaProductos;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var productos = new ObservableCollection<Producto>(Utils.Utils.ListaProductos);
        listaProductos.ItemsSource = productos;
    }

    private async void OnClickNuevoProducto(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NuevoProducto());
    }

    private async void onClickShowDetails(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Producto producto)
        {
            await Navigation.PushAsync(new DetailsProducto(producto));
        }
    }
}