using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class ChapmanKolmogorov
    {
        public readonly IList<DBHazardPDF> hazards;
        public int ModelID { get; private set; }
        public ChapmanKolmogorov(IList<DBHazardPDF> hazards,int modelID)
        {
            this.hazards = hazards;
            ModelID = modelID;
        }
        /// <summary>
        /// List of Hazards associated with jump.
        /// </summary>
        public decimal GetProbabilityOfJumpOutOfState(int timeIndex)
        {
            var result = 0m;
            foreach(var hzd in hazards)
            {
                result += hzd.GetDFTypeSpecificValueFromDb(timeIndex,1);
               
            }
            return result;
        }

        public DBHazardPDF GetHazardByTransitionCode(int code)
        {
            var ret = hazards.Single(s => s.StateFromToID == code);
            return ret;
        }
    }

   
}
