using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCMS
{
    public class RoiElement
    {
        public int id { set; get; }
        public double peak { set; get; }
        public int start { set; get; }
        public int end { set; get; }
    }
}
