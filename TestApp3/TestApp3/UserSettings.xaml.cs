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
	public partial class UserSettings : ContentPage
	{
		public UserSettings ()
        {
            InitializeComponent ();

            BuildContent();
		}

        private void BuildContent()
        {

            var first = NewEntry("First Name");
            var last = NewEntry("Last Name");
            var roomNum = NewEntry("Room Number");
            var floor = NewEntry("Floor");
            var totalChildren = NewEntry("Total Children In Class");



            Content = new StackLayout
            {
                Spacing = 10,
                Margin = 10,
                Children = { first, last, roomNum, floor, totalChildren },

            };
        }


        private Entry NewEntry(string placeholder)
        {
            return new Entry
            {
                Placeholder = placeholder,
                PlaceholderColor = Color.White,
                TextColor = Color.White,
                FontSize = 11,

            };
        }
	}
}