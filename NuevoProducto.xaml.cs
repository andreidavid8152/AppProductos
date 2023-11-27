using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MauiApp1.Models;
using MauiApp1.Service;

namespace MauiApp1;

public partial class NuevoProducto : ContentPage
{
    private Producto _producto;
    private readonly APIService _apiService;

    public NuevoProducto(APIService apiService)
	{
		InitializeComponent();
        _apiService = apiService;
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
        // Verifica si _producto es null y si es así, crea una nueva instancia
        if (_producto == null)
        {
            _producto = new Producto();
        }

        // Actualiza los datos del producto con los valores de los campos
        _producto.Nombre = Nombre.Text;
        _producto.Cantidad = Int32.Parse(Cantidad.Text);
        _producto.Descripcion = Descripcion.Text;

        if (_producto.IdProducto != 0)
        {
            // Actualizar producto existente
            await _apiService.PutProducto(_producto.IdProducto, _producto);
        }
        else
        {
            // Crear nuevo producto
            await _apiService.PostProducto(_producto);
        }

        await Navigation.PopAsync();
    }
}
