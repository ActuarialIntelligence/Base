using ActuarialIntelligence.Domain.Model_Containers.ModelInterfaces;

namespace ActuarialIntelligence.Domain.Model_Containers
{
    public class ModelContainer : IModel
    {
        public IModelContainer container { get; private set; }

        public ModelContainer(IModelContainer container)
        {
            this.container = container;
        }

    }
}
