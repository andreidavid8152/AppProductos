using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MauiApp1.Models;

namespace MauiApp1;

public partial class NuevoProducto : ContentPage
{
	public NuevoProducto()
	{
		InitializeComponent();
	}

    private async void OnClickGuardarNuevoProducto(object sender, EventArgs e)
    {
        var toast = Toast.Make("Click en guardar producto", ToastDuration.Short, 14);

        await toast.Show();

        Producto producto = new Producto
        {

            IdProducto = 0,
            Nombre = Nombre.Text,
            Descripcion = Descripcion.Text,
            Cantidad = Int32.Parse(Cantidad.Text)
        
        };

        Utils.Utils.ListaProductos.Add(producto);

    }
}