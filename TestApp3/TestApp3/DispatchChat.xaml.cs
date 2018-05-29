using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp3
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DispatchChat : ContentPage
	{
		public DispatchChat ()
		{
			InitializeComponent ();


            var btnTest = new Button
            {
                Text = "Test"
            };
            btnTest.Clicked += BtnTest_Clicked;
            Content = new StackLayout
            {
                Children = { btnTest }
            };
		}

        private void BtnTest_Clicked(object sender, EventArgs e)
        {
            Geolocation geo = new Geolocation();
            if (geo.CanUseGeolocation())
            {
                geo.GetPosition();
                //geo.RequestLocation();
            }
            
        }
    }
}