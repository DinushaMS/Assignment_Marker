using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Marker_New
{
    class Annotation
    {
        public int x { get; set; }
        public int y { get; set; }
        public char Type { get; set; }
        public string text { get; set; }
        public bool isSelceted { get; set; }
    }
}
