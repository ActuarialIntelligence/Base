using System.Collections.Generic;

namespace ActuarialIntelligence.Domain.NeuronParametrix
{
    public class NeuralObjectList
    {
        public IList<NeuralObject> neuralObjectList { get; private set; }
        public NeuralObjectList(IList<NeuralObject> neuralObjectList)
        {
            this.neuralObjectList = neuralObjectList;
        }
    }
}
