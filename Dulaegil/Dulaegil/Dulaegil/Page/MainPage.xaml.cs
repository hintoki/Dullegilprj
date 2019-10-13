using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Dulaegil
{
    public partial class MainPage : ContentPage
    {
        private Global gs = Global.inst;

        public MainPage()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            //TODO .. 웹에서 모든 둘레길의 정보를 받아옴. 아마도 Json 사용
            gs.dic_dullegilInfo = new Dictionary<int, DullegilInfo>();

            //Sample DullegilInfo
            for(int i = 1; i <= 12; i++)
            {
                DullegilInfo newDullegillInfo = new DullegilInfo();
                newDullegillInfo.name = "둘레길 " + i.ToString();
                if (i <= 10) newDullegillInfo.distance = 10;
                else         newDullegillInfo.distance = 12;
                newDullegillInfo.address = "수원시 영통구 이의동 창룡대로 250 둘레길 " + i.ToString();

                if (i % 3 == 0) newDullegillInfo.level = "상";
                if (i % 3 == 1) newDullegillInfo.level = "중";
                if (i % 3 == 2) newDullegillInfo.level = "하";

                gs.dic_dullegilInfo.Add(i, newDullegillInfo);
            }


            //TODO.. DB로 부터 User 정보를 받아옴.
            gs.userInfo = new UserInfo();

            //Sample userInfo
            gs.userInfo.ID = "Hintokki";
            gs.userInfo.rank = 1;
            gs.userInfo.totalDis = 124;

            gs.userInfo.dullegilList = new List<int>(); //유저가 방문했던 둘레길 정보 리스트

            for(int i = 1; i <= 12; i++)
            {
                gs.userInfo.dullegilList.Add(i);
            }
        }

        private async void StartBtn_Clicked(object sender, EventArgs e)
        {
            IntroPage introPage = new IntroPage();
            await Navigation.PushModalAsync(introPage);
        }
    }
}
