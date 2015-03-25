using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleAnalyzer.Core
{
    public class RectanglesAnalysis
    {
        public EquivalencyAnalysis EquivalencyAnalysis { get; set; }
        public IntersectionAnalysis IntersectionAnalysis { get; set; }
        public ContainmentAnalysis ContainmentAnalysis { get; set; }
        public AdjacencyAnalysis AdjacencyAnalysis { get; set; }
        public CongruenceAnalysis CongruenceAnalysis { get; set; }
        public SimilarityAnalysis SimilarityAnalysis { get; set; }


        public IEnumerable<string> GetSummary()
        {
            if (EquivalencyAnalysis.EquivalencyPresent)
            {
                yield return EquivalencyAnalysis.Message;
            }
            else
            {
                yield return IntersectionAnalysis.Message;
                yield return CongruenceAnalysis.Message;
                yield return AdjacencyAnalysis.Message;
                yield return CongruenceAnalysis.Message;
                yield return SimilarityAnalysis.Message;
            }
        }

    }
}
