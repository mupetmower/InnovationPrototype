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
	public partial class CallType : ContentPage
	{
        CADHttpClient cadHttp;
        string locationInfo = "From First Alert";

		public CallType ()
		{          
            AuthenticateCadConnection();

            InitializeComponent();

            BuildContent();

        }


        private void BuildContent()
        {
            //FUTURE - Color.FromHex for better colors            
            BackgroundColor = Color.Navy;
            Padding = new Thickness(15);

            var police = new Button
            {
                Text = "Police",
                TextColor = Color.White,
                BackgroundColor = Color.Blue,
                FontSize = 35,
            };
            police.Clicked += Police_Clicked;

            var fire = new Button
            {
                Text = "Fire",
                TextColor = Color.White,
                BackgroundColor = Color.Firebrick,
                FontSize = 35,
            };
            fire.Clicked += Fire_Clicked;

            var ems = new Button
            {
                Text = "EMS",
                TextColor = Color.White,
                BackgroundColor = Color.Gold,
                FontSize = 35,

            };
            ems.Clicked += EMS_Clicked;


            Content = new StackLayout
            {
                Spacing = 35,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = { police, fire, ems }
            };


            

        }



        public void AuthenticateCadConnection()
        {
            try
            {
                cadHttp = new CADHttpClient();
                cadHttp.Connect();
                //onsole.WriteLine("Connection SUCCESS!");
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }
        }


        private void CreateCadIncident(string city, string callerName, string eventName, string locInfo, string address, string callerNum)
        {
            try
            {
                NewIncident newIncident = cadHttp.CreateTestIncident(city, callerName, eventName, locInfo, address, callerNum);

                IncidentResponse response = cadHttp.SendIncident(newIncident);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }
        }


        public void Police_Clicked(object sender, EventArgs e)
        {
            try
            {
                CreateCadIncident("Denver", "Jenny", CADDispositionTypes.SHOTS_FIRED, locationInfo, "123 Green St", "8675309");
                ShowDispostion(AlertType.Police);                
                //Console.WriteLine("Tracking Number Returned: " + response.incident.tracking_number);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public void Fire_Clicked(object sender, EventArgs e)
        {
            try
            {
                CreateCadIncident("Colorado Springs", "Tom", CADDispositionTypes.FIRE, locationInfo, "333 3rd St", "7195659985");
                ShowDispostion(AlertType.Fire);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public void EMS_Clicked(object sender, EventArgs e)
        {
            try
            {
                CreateCadIncident("Boulder", "Nancy", CADDispositionTypes.CHEST_PAIN, locationInfo, "98 Peace Ln", "3036559104");
                ShowDispostion(AlertType.EMS);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }
        }


        private void ShowDispostion(AlertType type)
        {
            var master = this.Parent as TabbedPage;
            Disposition dispositionPage = (Disposition) master.Children[1];
            dispositionPage.BindingContext = new DispositionViewModel { TypeOfAlert = type };
            //Navigation.NavigationStack.Append(this);
            
            master.CurrentPage = dispositionPage;
        }


    }


    
}