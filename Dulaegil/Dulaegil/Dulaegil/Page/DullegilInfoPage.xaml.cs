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
	public partial class DullegilInfoPage : ContentPage
	{
        Global gs = Global.inst;

		public DullegilInfoPage ()
		{
			InitializeComponent ();
		}

        public void Init(int gil_ID)
        {
            lt_dullegilName.Text = gs.dic_dullegilInfo[gil_ID].name;
            lt_address.Text = gs.dic_dullegilInfo[gil_ID].address;
            lt_distance.Text = gs.dic_dullegilInfo[gil_ID].distance.ToString() + " km";
            lt_level.Text = gs.dic_dullegilInfo[gil_ID].level;
        }
	}
}