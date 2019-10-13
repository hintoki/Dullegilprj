using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dulaegil
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentView
	{
		public MapPage ()
		{
			InitializeComponent ();
            Init();
		}

        public void Init()
        {
        }
	}
}