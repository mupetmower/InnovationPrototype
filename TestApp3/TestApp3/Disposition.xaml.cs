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
	public partial class Disposition : ContentPage
	{
		public Disposition ()
        {            
            InitializeComponent ();
		}


        public void PrintResources()
        {
            Console.WriteLine("Resources: " + Resources.Keys + "\n" + Resources.Values);
        }
	}
}