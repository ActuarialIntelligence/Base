using ActuarialIntelligence.Domain.NeuronParametrix.Interfaces;
using System.Collections.Generic;

namespace ActuarialIntelligence.Domain.NeuronParametrix
{
    public class NeuralObjectList
    {
        public IList<IObject> neuralObjectList { get; private set; }
        public NeuralObjectList(IList<IObject> neuralObjectList)
        {
            this.neuralObjectList = neuralObjectList;
        }
    }
}
