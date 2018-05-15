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
            BackgroundColor = Color.Navy;
            
            //this.HeightRequest = 5;
            Children.Add(new CallType { Icon = "bellicon.png", Title = "Type" });
            Children.Add(new Disposition { Icon = "dispositionicon.png", Title = "Disposition" });
            Children.Add(new Details { Icon = "papericon.png", Title = "Details" });
            Children.Add(new DispatchChat { Icon = "dispatchchaticon.png", Title = "Chat" });
            

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
