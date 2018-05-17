using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp3
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Disposition : ContentPage, INotifyPropertyChanged
    {
		public Disposition ()
        {            
            InitializeComponent ();

            
            //BuildContent();
        }

        protected override void OnBindingContextChanged()
        {
            BuildContent();
        }


        private void BuildContent()
        {
            //Enum.TryParse(alerttype.Text, out AlertType type);
            //Console.WriteLine("Alert Type = " + alerttype.Text + "\n" + "Binding Value = " + type.ToString());

            DispositionViewModel dvm = (DispositionViewModel)BindingContext;
            Console.WriteLine("Alert Type = " + dvm.TypeOfAlert);
            switch (dvm.TypeOfAlert)
            {
                case (AlertType.Police):
                    BuildPoliceContent();
                    break;
                case (AlertType.Fire):
                    BuildFireContent();
                    break;
                case (AlertType.EMS):
                    BuildEMSContent();
                    break;

            }
        }



        public void BuildPoliceContent()
        {
            var shotsFired = NewDispositionButton("Shots Fired");
            var fight = NewDispositionButton("Fight");
            var verbalThreats = NewDispositionButton("Verbal Threats");
            var theft = NewDispositionButton("Theft");
            var other = NewDispositionButton("Other");
            var title = new Label
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 20,
                Text = "Emergency Type",
                TextColor = Color.White,
            };

            //Content = NewStackLayout();

            Content = new StackLayout
            {
                Spacing = 10,
                Margin = 10,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {title, shotsFired, fight, verbalThreats, theft, other},

            };
        }

        
        public void BuildFireContent()
        {
            var fire = NewDispositionButton("Fire");
            var fireAlarm = NewDispositionButton("Fire Alarm");
            var gasLeak = NewDispositionButton("Gas Leak");
            var explosion = NewDispositionButton("Explosion");
            var other = NewDispositionButton("Other");
            var title = new Label
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 20,
                Text = "Emergency Type",
                TextColor = Color.White,
            };

            Content = new StackLayout
            {
                Spacing = 10,
                Margin = 10,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { title, fire, fireAlarm, gasLeak, explosion, other },

            };
        }

        public void BuildEMSContent()
        {
            var unresponsive = NewDispositionButton("Unresponsive");
            var notBreathing = NewDispositionButton("Not Breathing");
            var chestPain = NewDispositionButton("Chest Pain");
            var wounded = NewDispositionButton("Wounded");
            var other = NewDispositionButton("Other");
            var title = new Label
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 20,
                Text = "Emergency Type",
                TextColor = Color.White,
            };

            Content = new StackLayout
            {
                Spacing = 10,
                Margin = 10,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { title, unresponsive, notBreathing, chestPain, wounded, other },

            };
        }


        private StackLayout NewStackLayout(object[] controls)
        {
            return new StackLayout
            {
                Spacing = 10,
                VerticalOptions = LayoutOptions.FillAndExpand

            };
        }

        private Button NewDispositionButton(string text, Color color)
        {
            var newButton = new Button
            {
                Text = text,
                TextColor = color,
                BackgroundColor = Color.FromHex("E4AE24"),
                FontSize = 15,
            };

            return newButton;
        }

        private Button NewDispositionButton(string text)
        {
            var newButton = new Button
            {
                Text = text,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("E4AE24"),
                FontSize = 15,
            };

            return newButton;
        }



        private void UpdateIncidentDisposition(string dispositionType)
        {
            try
            {
                CADHttpClient cadHttp = new CADHttpClient();
                //FUTURE - instead of connecting each time, check to see if authToken is still valid, if not authenticate again, if so continue without new auth
                cadHttp.Connect();
                IncidentResponse response = cadHttp.GetIncident(CADHttpClient.incidentTrackingNumber);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }
        }


    }

    
}