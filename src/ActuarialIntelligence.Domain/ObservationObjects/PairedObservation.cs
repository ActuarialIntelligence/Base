using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ObservationObjects
{
    public class PairedObservation
    {
        public decimal total { get; private set; }
        public decimal deaths { get; private set; }
        public decimal unitTime { get; private set; }
        public PairedObservation(decimal total, decimal deaths,decimal unitTime)
        {
            this.total = total;
            this.deaths = deaths;
            this.unitTime = unitTime;
        }
    }
}
