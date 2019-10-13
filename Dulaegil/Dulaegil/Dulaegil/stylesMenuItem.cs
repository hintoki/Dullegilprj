using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dulaegil
{

    public class stylesMenuItem
    {
        public stylesMenuItem()
        {
            TargetType = typeof(stylesDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}