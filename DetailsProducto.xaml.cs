using CommunityToolkit.Maui.Core;
using MauiApp1.Models;

namespace MauiApp1;

public partial class DetailsProducto : ContentPage
{
    private Producto _producto;
	public DetailsProducto()
	{
		InitializeComponent();
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
        await Navigation.PushAsync(new NuevoProducto()
        {
            BindingContext = _producto,
        });
    }

    private async void ClickEliminarProducto(object sender, EventArgs e)
    {
        Utils.Utils.ListaProductos.Remove(_producto);
        await Navigation.PopAsync();
    }
}