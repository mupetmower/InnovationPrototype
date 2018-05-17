using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestApp3
{
	public partial class MainPage : TabbedPage
	{
		public MainPage()
		{
            //NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            BackgroundColor = Color.FromHex("171b4a");

            //this.HeightRequest = 5;
            Children.Add(new CallType { Icon = "bellicon.png", Title = "Alrt" });
            Children.Add(new Disposition { Icon = "alerticon.png", Title = "Type" });
            Children.Add(new Details { Icon = "papericon.png", Title = "Info" });
            Children.Add(new DispatchChat { Icon = "dispatchchaticon.png", Title = "Chat" });

            //Children.Add(new UserSettings { Icon = "usersettingsicon.png", Title = "User" });


            //FUTURE - put settings buttton separate, maybe one of those "three-horizontal-lines-buttons"
            //Children.Add(new UserSettings { Icon = "usersettingsicon.png", Title = "Settings" });

        }


        protected override bool OnBackButtonPressed()
        {
            //CurrentPage = Navigation.NavigationStack.Last();

            return true;
        }
	}
}
