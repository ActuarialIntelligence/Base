using System;
using System.IO;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;

// Define a class to hold your data structure
public class InputData
{
    [LoadColumn(0)]
    public float Ip1 { get; set; }

    [LoadColumn(1)]
    public float Ip2 { get; set; }

    [LoadColumn(2)]
    public float Ip3 { get; set; }

    [LoadColumn(3)]
    public float Ip4 { get; set; }

    [LoadColumn(4), ColumnName("Label")]
    public bool Fraud { get; set; }
}

// Define a class to hold your prediction
public class OutputData
{
    [ColumnName("PredictedLabel")]
    public bool Prediction { get; set; }
}

public class Predictor
{
    public static string PredictMovement(InputData inputData)
    {
        // Set paths for data and model
        var dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "input_data.csv");
        var secondDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "second_input_data.csv");
        var modelPath = Path.Combine(Environment.CurrentDirectory, "Model", "trained_model.zip");

        // Create a ML.NET context
        var mlContext = new MLContext();

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

        // Reload the trained model
        var reloadedModel = mlContext.Model.Load(modelPath, out var modelInputSchema);

        // Load the second input data file (features only)
        var secondDataView = mlContext.Data.LoadFromTextFile<InputData>(
            path: secondDataPath,
            hasHeader: true,
            separatorChar: ',');
        var input = new InputData();
        // Make predictions on the second input data
        var predictions = mlContext.Model.CreatePredictionEngine<InputData, OutputData>(reloadedModel)
            .Predict(input);

        // Display predictions
        Console.WriteLine("Predictions for the second input data:");
        //foreach (var prediction in predictions)
        //{
            Console.WriteLine($"Prediction: {predictions.Prediction}");
        //}
        return predictions.Prediction.ToString();
    }
}
