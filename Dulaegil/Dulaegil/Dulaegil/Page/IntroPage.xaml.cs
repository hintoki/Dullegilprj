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
	public partial class IntroPage : ContentPage
	{
        private Global gs = Global.inst;

		public IntroPage ()
		{
			InitializeComponent ();
            Init();
		}

        public void Init()
        {
            //gs.GetJson();

            //foreach(JParam jp in gs.jparamList)
            //{
            //    //stackPanel.AddButton(jp.location, 150);
            //}

            lt_recommendDetails.Text = "지리산둘레길\n '둘레길은 사랑을 담고'\n" +
                 " 파란하늘과 푸르름을 가득안고 있는\n" +
                 " 함양군 마천면 창원마을에 위치한 하늘\n" +
                 " 길을 걸으며 바라본 두 부부의 모습은\n" +
                 " 둘레길을 걷는 것만으로도 사랑이\n" +
                 " 피어 오를것만 같은 참 아름다운 모습이다.";
        }

        //하트 버튼 클릭 시 사용자 정보 창으로 이동
        private async void heartBtn_Clicked(object sender, EventArgs e)
        {
            UserInfoPage userInfoPage = new UserInfoPage();
            userInfoPage.Init(gs.userInfo);

            await Navigation.PushModalAsync(userInfoPage);
        }

        private void Btn1_Clicked(object sender, EventArgs e)
        {
            //버튼 1 클릭시 동작
        }

        private void Btn2_Clicked(object sender, EventArgs e)
        {
            //버튼 2 클릭시 동작
        }

        private void RecommendBtn_Clicked(object sender, EventArgs e)
        {
            //추천된 둘레길 정보 창으로 이동
        }

        private void DullegilList_btn_Clicked(object sender, EventArgs e)
        {
            //모든 둘레길 정보를 리스트로 보여주는 창으로 이동
        }

        private void Ranking_btn_Clicked(object sender, EventArgs e)
        {
            //랭킹 창으로 이동
        }

        private void Together_btn_Clicked(object sender, EventArgs e)
        {
            //함께하기 창으로 이동
        }
    }
}