using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WeatherPage : ContentPage
	{
		public WeatherPage()
		{
			InitializeComponent ();

            BindingContext = new Weather();
		}

	    private async void GetWeatherBtn_Clicked(object sender, EventArgs e)
	    {
	        if (String.IsNullOrEmpty(zipCodeEntry.Text))
	            return;

	        Weather weather = await Core.GetWeather(zipCodeEntry.Text);
	        BindingContext = weather;
	        getWeatherBtn.Text = "Search Again";
	    }
	}
}