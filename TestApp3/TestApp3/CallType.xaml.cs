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
                
                BackgroundColor = Color.Blue,
                FontSize = 35
            };
            police.Clicked += Police_Clicked;

            var fire = new Button
            {
                Text = "Fire",
                BackgroundColor = Color.Firebrick,
                FontSize = 35
            };
            fire.Clicked += Fire_Clicked;

            var ems = new Button
            {
                Text = "EMS",
                BackgroundColor = Color.Gold,
                FontSize = 35  
            };
            ems.Clicked += EMS_Clicked;


            Content = new StackLayout
            {
                Spacing = 30,
                VerticalOptions = LayoutOptions.FillAndExpand,
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


        private void CreateCadIncident()
        {
            try
            {
                NewIncident newIncident = cadHttp.CreateTestIncident();

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
                CreateCadIncident();
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
                CreateCadIncident();
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
                CreateCadIncident();
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
            var dispositionPage = master.Children[1];
            dispositionPage.BindingContext = new TypeOfAlert { Type = type };
            //Navigation.NavigationStack.Append(this);
            master.CurrentPage = dispositionPage;
        }


    }


    class TypeOfAlert
    {
        public AlertType Type { get; set; }
    }
}