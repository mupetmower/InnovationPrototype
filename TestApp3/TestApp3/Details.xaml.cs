using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp3
{
    public enum AlertType
    {
        Police, Fire, EMS
    }

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Details : ContentPage
	{
        private AlertType alertType;

		public Details ()
        {
            InitializeComponent ();

            
        }


        private void InitControls()
        {
            var layout = new StackLayout();
            var header = new Label
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Text = String.Format("{0} Emergency Details", alertType)
            };


            

            var oneBox = new BoxView { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            var twoBox = new BoxView { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            var threeBox = new BoxView { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };

            layout.Children.Add(header);
            layout.Children.Add(oneBox);
            layout.Children.Add(twoBox);
            layout.Children.Add(threeBox);

            Content = layout;
            
        }


	}
}