using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MauiApp1.Models;

namespace MauiApp1;

public partial class NuevoProducto : ContentPage
{
    private Producto _producto;

    public NuevoProducto()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _producto = BindingContext as Producto;
        if (_producto != null)
        {
            Nombre.Text = _producto.Nombre;
            Cantidad.Text = _producto.Cantidad.ToString();
            Descripcion.Text = _producto.Descripcion;
        }
    }

    private async void OnClickGuardarNuevoProducto(object sender, EventArgs e)
    {
        if (_producto != null)
        {
            _producto.Nombre = Nombre.Text;
            _producto.Cantidad = Int32.Parse(Cantidad.Text);
            _producto.Descripcion = Descripcion.Text;
        }
        else
        {

            Producto producto = new Producto
            {
                IdProducto = 0,
                Nombre = Nombre.Text,
                Descripcion = Descripcion.Text,
                Cantidad = Int32.Parse(Cantidad.Text)
            };

            Utils.Utils.ListaProductos.Add(producto);
        }
        await Navigation.PopAsync();
    }
}
