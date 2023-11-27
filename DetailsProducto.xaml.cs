using CommunityToolkit.Maui.Core;
using MauiApp1.Models;
using MauiApp1.Service;

namespace MauiApp1;

public partial class DetailsProducto : ContentPage
{
    private Producto _producto;
    private APIService _api;

    public DetailsProducto(APIService api)
	{
		InitializeComponent();
        _api = api;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _producto = BindingContext as Producto;
        Nombre.Text = _producto.Nombre;
        Cantidad.Text = _producto.Cantidad.ToString();
        Descripcion.Text = _producto.Descripcion;
    }

    private async void ClickEditarProducto(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NuevoProducto(_api)
        {
            BindingContext = _producto,
        });
    }

    private async void ClickEliminarProducto(object sender, EventArgs e)
    {
        await _api.DeleteProducto(_producto.IdProducto);
        await Navigation.PopAsync();
    }
}