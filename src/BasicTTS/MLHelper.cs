using System;
using System.IO;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;

// Define a class to hold your data structure
public class InputData
{
    [LoadColumn(0)]
    public float Word { get; set; }


    [LoadColumn(1), ColumnName("Label")]
    public bool Image { get; set; }
}

// Define a class to hold your prediction
public class OutputData
{
    [ColumnName("PredictedLabel")]
    public bool Image { get; set; }
}

public class Predictor
{
    public static string PredictMovement(InputData inputData)
    {
        string modelPath;

        modelPath = Path.Combine(Environment.CurrentDirectory, "Model", "trained_model.zip");
        
        // Create a ML.NET context
        var mlContext = new MLContext();
        // Reload the trained model
        var reloadedModel = mlContext.Model.Load(modelPath, out var modelInputSchema);

        // Load the second input data file (features only)
        //var secondDataView = mlContext.Data.LoadFromTextFile<InputData>(
        //    path: secondDataPath,
        //    hasHeader: true,
        //    separatorChar: ',');
        var input = new InputData();
        // Make predictions on the second input data
        var predictions = mlContext.Model.CreatePredictionEngine<InputData, OutputData>(reloadedModel)
            .Predict(input);

        // Display predictions
        Console.WriteLine("Predictions for the second input data:");
        //foreach (var prediction in predictions)
        //{
        Console.WriteLine($"Prediction: {predictions.Image}");
        //}
        return predictions.Image.ToString();
    }

    public static void TrainAndSave(string modelPath)
    {
        var mlContext = new MLContext();
        // Set paths for data and model
        var dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "input_data.csv");
        //var secondDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "second_input_data.csv");
        modelPath = Path.Combine(Environment.CurrentDirectory, "Model", "trained_model.zip");

        // Create a ML.NET context
        mlContext = new MLContext();

        // Load data
        var dataView = mlContext.Data.LoadFromTextFile<InputData>(
            path: dataPath,
            hasHeader: true,
            separatorChar: ',');

        // Split data into training and testing sets
        var trainTestSplit = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.3);
        var trainData = trainTestSplit.TrainSet;
        var testData = trainTestSplit.TestSet;

        // Define data preparation pipeline
        var dataProcessPipeline = mlContext.Transforms.Concatenate("Features", "Ip1", "Ip2", "Ip3", "Ip4")
            .Append(mlContext.Transforms.NormalizeMinMax("Features"));

        // Create a Logistic Regression model
        var trainer = mlContext.BinaryClassification.Trainers.LbfgsLogisticRegression();
        var trainingPipeline = dataProcessPipeline.Append(trainer);

        // Train the model
        var model = trainingPipeline.Fit(trainData);

        // Save the trained model
        mlContext.Model.Save(model, trainData.Schema, modelPath);
    }
}
