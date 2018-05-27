using System.Linq;

namespace Domain
{
    public class DBHazardPDF
    {
        private StatAIEntities context;
        public int StateFromToID { get; private set; }
        public string ModelId { get; private set; }
        public string startDate { get; private set; }
        public DBHazardPDF(StatAIEntities context, int stateID, string modelId, string startDate)
        {
            StateFromToID = stateID;
            ModelId = modelId;
            this.context = context;
            this.startDate = startDate;
        }

        public decimal GetDFTypeSpecificValueFromDb(int timeIndex,int DFTypeID)
        {
            //Report.Write("s.TimeIndex == "+ timeIndex + " && s.StartDate ==" + startDate+ " && s.ModelID ==" + ModelId + " && s.StateID == " + StateFromToID + "&& s.DFTypeID == " + DFTypeID);
            //return context.HazardPDFs.SingleOrDefault(s => s.TimeIndex == 
            //timeIndex && s.StartDate == startDate && s.ModelID == ModelId 
            //&& s.StateID == StateFromToID && s.DFTypeID == DFTypeID) == null? 0 : (decimal)context.HazardPDFs.Single(s => s.TimeIndex ==
            // timeIndex && s.StartDate == startDate && s.ModelID == ModelId
            // && s.StateID == StateFromToID && s.DFTypeID == DFTypeID).PointY;
            return 0;
        }
    }
}
