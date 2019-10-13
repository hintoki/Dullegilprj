using System;
using System.Collections.Generic;
using System.Text;

namespace Dulaegil
{
    public class JParam
    {
        public string location;
        public string distance;
        public string walk_time;
        public string course_num;
        public string course_level;
        public string course_name;

        public JParam(string loc, string dis, string walk, string cn, string cl, string cnm)
        {
            location = loc;
            distance = dis;
            walk_time = walk;
            course_num = cn;
            course_level = cl;
            course_name = cnm;
        }
    }
}
