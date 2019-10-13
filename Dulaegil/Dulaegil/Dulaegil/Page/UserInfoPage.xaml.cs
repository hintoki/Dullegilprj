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
	public partial class UserInfoPage : ContentPage
	{
        Global gs = Global.inst;

		public UserInfoPage ()
		{
			InitializeComponent ();

		}
        
        public void Init(UserInfo userInfo)
        {
            lt_rank.Text = userInfo.rank.ToString() + " 등";
            lt_totalDis.Text = userInfo.totalDis.ToString() + " km";

            foreach(int gil_ID in userInfo.dullegilList)
            {
                Button newBtn = new Button();
                newBtn.Text = "       " + gs.dic_dullegilInfo[gil_ID].name;
                newBtn.StyleId = gil_ID.ToString();
                newBtn.TextColor = Color.Black;
                newBtn.BackgroundColor = Color.Transparent;
                newBtn.FontSize = 17; //medium
                newBtn.Clicked += Dullegil_btn_click;
                sl_userInfo.Children.Add(newBtn);
            }
        }

        private async void Dullegil_btn_click(object sender, EventArgs e)
        {
            //해당 둘레길 의 정보를 보여주는 창으로 이동
            DullegilInfoPage dullegillInfoPage = new DullegilInfoPage();
            int gil_ID = Convert.ToInt32((sender as Button).StyleId);
            dullegillInfoPage.Init(gil_ID);

            await Navigation.PushModalAsync(dullegillInfoPage);
        }

        private async void BackBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}