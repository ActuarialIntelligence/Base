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
    /// This way the physical characteristics are 'really' expressible. 
    /// 
    /// The way to get to a resolution is to align the requirements of the 
    /// objective with parameters existing within all available objects.
    /// 
    /// Creativity is the question: What are my objects supposed to have(in the way of properties) in 
    /// order to fulfill the objective?  
    ///  
    /// Use some type of reflection; height in objective can be matched with height in object for 
    /// comparison. All properties can be matched in this manner.
    /// 
    /// 
    /// At a future date; have a separate module that will update object properties within the class
    /// itself (Such as object elasticity) when the module finds this property; i.e.
    /// it should enter it into the class as a variable with property name 'elasticity'
    /// automatically without human intervention
    /// </summary>
    public class NeuralProcessor
    {

    }
}
