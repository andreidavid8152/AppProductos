using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;
using System.Threading;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;


namespace MauiApp1;

public partial class ProductoPage : ContentPage
{
	public ProductoPage()
	{
		InitializeComponent();
    }

    private async void OnClickNuevoProducto(object sender, EventArgs e)
    {
        var toast = Toast.Make("Click en nuevo producto", ToastDuration.Short, 14);

        await toast.Show();
    }
}