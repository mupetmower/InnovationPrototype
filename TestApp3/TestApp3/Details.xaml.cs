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

            BuildContent();
        }


        private void BuildContent()
        {
            var layout = new StackLayout();
            var title = new Label
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Text = String.Format("{0} Emergency Details", alertType),
                FontSize = 15,
                TextColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, 10, 0, 20),
            };


            var lblTitle = new Label
            {
                Text = "Details Page Title",
                FontSize = 30,
                TextColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, 10, 0, 20)
            };


            var entryName = new Entry
            {
                Placeholder = "Enter your name",
                PlaceholderColor = Color.FromRgba(255, 255, 255, 0.8),
                TextColor = Color.White,
                Margin = new Thickness(15, 0, 15, 15),
                FontSize = 11
            };


            var entryRoomNumber = new Entry
            {
                Placeholder = "Enter your room number",
                PlaceholderColor = Color.FromRgba(255, 255, 255, 0.8),
                TextColor = Color.White,
                Margin = new Thickness(15, 0, 15, 15),
                FontSize = 11,
                Keyboard = Keyboard.Numeric
            };


            var entryFloor = new Entry
            {
                Placeholder = "Enter your floor",
                PlaceholderColor = Color.FromRgba(255, 255, 255, 0.8),
                TextColor = Color.White,
                Margin = new Thickness(15, 0, 15, 15),
                FontSize = 11,
                Keyboard = Keyboard.Numeric
            };


            var entryAccountedFor = new Entry
            {
                Placeholder = "Students Accounted For",
                PlaceholderColor = Color.FromRgba(255, 255, 255, 0.8),
                TextColor = Color.White,
                Margin = new Thickness(15, 0, 15, 15),
                FontSize = 11,
                Keyboard = Keyboard.Numeric
            };


            var entryNotAccountedFor = new Entry
            {
                Placeholder = "Students Unaccounted For",
                PlaceholderColor = Color.FromRgba(255, 255, 255, 0.8),
                TextColor = Color.White,
                Margin = new Thickness(15, 0, 15, 15),
                FontSize = 11,
                Keyboard = Keyboard.Numeric
            };



            this.Content = new ScrollView
            {
                Content = new StackLayout
                {

                    Children = { title, entryName, entryRoomNumber, entryFloor, entryAccountedFor, entryNotAccountedFor },
                    BackgroundColor = Color.FromHex("#171b4a")

                }
            };

        }


	}
}