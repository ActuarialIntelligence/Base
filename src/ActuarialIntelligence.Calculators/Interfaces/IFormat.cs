using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActuarialIntelligence.Calculators.Interfaces
{
    public interface IFormat<T>
    {
        T FormatAndReturn(int startpage, int endpage);
    }
}
