using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleAnalyzer.Core
{
    public class IntersectionAnalysis
    {
        public bool IntersectionPresent { get; set; }
        private RectangleF Intersection { get; set; }
        public List<PointF> IntersectionPoints { get; set; }

        public string Message { get; set; }

    }
}
