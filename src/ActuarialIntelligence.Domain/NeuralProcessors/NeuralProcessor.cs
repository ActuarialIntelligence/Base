namespace ActuarialIntelligence.Domain.NeuralProcessor
{
    /// <summary>
    /// Keep physical properties of objects as physically realisitc
    /// as possible: If only n-number of objects are allowed 
    /// then place n-objects within the object list; Do not have some parameter
    /// within the object that specifies the number of 'allowed to be used' objects.
    /// Make Time based return types for things that take a long time: i.e. 
    /// If I call a move() method then let one object take 5sec to respond while
    /// another only takes 0.2sec to respond on move().
    /// This way the physical characteristics are really expressible. 
    /// 
    /// The way to get to a resolution is to align the requirements of the 
    /// objective with parameters existing within all available objects.
    /// 
    /// Creativity is the question: What are my objects supposed to have(in the way of properties) in 
    /// order to fulfill the objective?  
    ///  
    /// </summary>
    public class NeuralProcessor
    {
    }
}
