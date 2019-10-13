using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Xamarin.Forms;

namespace Dulaegil
{    
    //user 정보 테이블
    public class UserInfo
    {
        public string ID { get; set; }
        public int rank { get; set; }
        public int totalDis { get; set; }
        public List<int> dullegilList { get; set; }
    }

    //둘레길 정보 테이블
    public class DullegilInfo
    {
        public string name { get; set; }
        public int distance { get; set; }
        public string address { get; set; }
        public string level { get; set; }
    }

    public class Global : Singleton<Global>
    {
        public UserInfo userInfo = null;
        public Dictionary<int, DullegilInfo> dic_dullegilInfo = null;

        public string jsonTest = null;
        public Dictionary<int, JParam> dic = null;
        public List<JParam> jparamList = null;
        string msg, success;
        string loc, dis, walk, cn, cl, cnm; //json 파싱 테스트

        public Global()
        {
            dic = new Dictionary<int, JParam>();
            jparamList = new List<JParam>();
            msg = "";
            success = "";
        }
        
        public void SetVal(string key, string val)
        {
            if (key == "LOCATION")          loc = val;
            else if (key == "DISTANCE")     dis = val;
            else if (key == "WALK_TIME")    walk = val;
            else if (key == "COURSE_NO")    cn = val;
            else if (key == "COURSE_LEVEL") cl = val;
            else if (key == "COURSE_NM")    cnm = val;
            else if (key == "msg")          msg = val;
            else if (key == "success")      success = val;
        }

        public void GetJson()
        {
            using (WebClient wc = new WebClient())
            {
                jsonTest = wc.DownloadString("https://mplatform.seoul.go.kr/api/dule/courseBaseInfo.do");

                int n = jsonTest.Length;

                int idx = 0;
                int icnt = 0;
                int cnt = 0;
                string key = "";
                string val = "";
                bool isVal = false;

                foreach(char ch in  jsonTest)
                {
                    if(ch == ':')
                    {
                        isVal = true;
                        continue;
                    }

                    if (ch == ',' && !isVal) continue;
                    if (ch == '[' || ch == ']')
                    {
                        isVal = false;
                        continue;
                    }

                    if(ch == '{')
                    {
                        icnt++;
                        continue;
                    }

                    if(ch == '}')
                    {                        
                        if (icnt > 0)
                        {
                            JParam newJParam = new JParam(loc, dis, walk, cn, cl, cnm);
                            jparamList.Add(newJParam);
                            dic.Add(idx++, newJParam);
                         }
                        icnt--;
                        continue;
                    }

                    if(ch == '"')
                    {
                        if(isVal)
                        {
                            if (cnt == 0) val = "";
                            else
                            {
                                SetVal(key, val);
                                isVal = false;
                            }                            
                        }
                        else
                        {
                            if (cnt == 0) key = "";                            
                        }

                        cnt++;
                        cnt %= 2;
                        continue;
                    }

                    if (isVal)      val += ch;
                    else            key += ch;

                }

            }
        }
    }
}
