using ActuarialIntelligence.Domain.NeuronParametrix;

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
    /// 
    /// The processor will take for instance the least squares path toward selecting 
    /// object numerical properties; with the inclusion in the least squares estimation
    /// for the condition: e.g. 'Sum(ObjectHeights) = Objective.MinRequiredHeightWithinErrorMargin'
    /// That is .. let it choose the least square of the sum, and/or the least square of each 
    /// objective aggregation {sum,upper,  lower, e^{property},..whatever}.
    /// In essence; we are storing Sum(a) , Sum(b) etc and interpolating through this with linear 
    /// regressiong least fit.
    /// Let these aggregation calls sit in another object layer.
    /// 
    /// </summary>
    public static class NeuralProcessor
    {
        // Resolve Objective
        // in this isolated case; the objective is height 
        // 'How much' of each objects height do we choose to resolve the objective? 
        // Per objective ; Lagrange minimize through all neuralLearnedStorageObjectValues
        // to obtain the solution with fixed objectives as an equation constraint.
        // The other strategy/'way of thought' is to permute through object properties
        // and constraints and see if the objective can be met.
        // What we want is to have object properties dynamically assigned along with 
        // their constraints, and a means to effectively translate these constraints
        // mathematically somehow. Funcs and Delegates....
        // All objects must encapsulate their own properties and the effects can be tested
        // via delegates that point to implementations within Physics Engine Object.
        // For instance Push() will point to the effect of pushing an object with mass,Gravity properties
        // as dictated by the result of such a thing within the Physics Engine Object.
        // For simplicity Push() can always return a distance of say 1m per push() call.
        // Therefore Push and result can be stored and if there is no constraint on how many times any one
        // method can be called such as Puch() in this instance... No constraint will imply => method
        // can be called as many times as necessary.
        public static void Process()
        {
            var getAllObjectives = Objective.objective.Split('|');

        }
    }
}
