//using System;
//using System.IO;
//using System.Linq;
//using NumSharp;
//using OpenCvSharp;
//using Tensorflow;
//using Tensorflow.Hub;
//using static Tensorflow.Binding;

//class Program
//{
//    static void Main(string[] args)
//    {
//        string modelPath = "ssd_mobilenet_v2";
//        string imagePath = "input_image.jpg";
//        string outputImagePath = "output_image.jpg";

//        // Load the model from TensorFlow Hub
//        var model = LoadModelFromHub("https://tfhub.dev/tensorflow/ssd_mobilenet_v2/2");

//        // Preprocess the input image
//        var inputTensor = PreprocessImage(imagePath);

//        // Run the model
//        var outputs = model.Call(new Tensor[] { inputTensor });

//        // Extract detection results
//        var detectionBoxes = outputs[0]["detection_boxes"].numpy();
//        var detectionScores = outputs[0]["detection_scores"].numpy();
//        var detectionClasses = outputs[0]["detection_classes"].numpy();

//        // Highlight detected objects
//        HighlightObjects(imagePath, detectionBoxes, detectionScores, detectionClasses, outputImagePath);

//        Console.WriteLine($"Output image saved to {outputImagePath}");
//    }

//    static SavedModel LoadModelFromHub(string url)
//    {
//        var modulePath = Path.Combine(Path.GetTempPath(), "hub_module");
//        if (!Directory.Exists(modulePath))
//        {
//            Directory.CreateDirectory(modulePath);
//            Console.WriteLine($"Downloading model from {url} to {modulePath}");
//            // Manually download the model using HttpClient if tfhub.Module.download is unavailable
//            using (var client = new System.Net.Http.HttpClient())
//            {
//                var data = client.GetByteArrayAsync(url).Result;
//                File.WriteAllBytes(modulePath, data);
//            }
//        }
//        return SavedModel.Load(modulePath);
//    }

//    static Tensor PreprocessImage(string imagePath)
//    {
//        var img = Cv2.ImRead(imagePath);
//        Cv2.Resize(img, img, new Size(300, 300));
//        img.ConvertTo(img, MatType.CV_32F);
//        img = img / 255.0f; // Normalize to [0,1]
//        var imgArray = np.array(img.Reshape(new int[] { 1, 300, 300, 3 }));
//        return ops.convert_to_tensor(imgArray);
//    }

//    static void HighlightObjects(string imagePath, NDArray detectionBoxes, NDArray detectionScores, NDArray detectionClasses, string outputImagePath, float threshold = 0.5f)
//    {
//        var img = Cv2.ImRead(imagePath);
//        int height = img.Height;
//        int width = img.Width;

//        for (int i = 0; i < detectionScores.size; i++)
//        {
//            float score = detectionScores[i].ToSingle();
//            if (score < threshold) continue;

//            int classId = detectionClasses[i].ToInt32();
//            if (classId != 1 && classId != 43 && classId != 37) continue;  // Filter only relevant classes

//            float[] box = detectionBoxes[i].ToArray<float>();

//            int yMin = (int)(box[0] * height);
//            int xMin = (int)(box[1] * width);
//            int yMax = (int)(box[2] * height);
//            int xMax = (int)(box[3] * width);

//            Cv2.Rectangle(img, new Point(xMin, yMin), new Point(xMax, yMax), Scalar.Green, 2);
//            string label = GetLabel(classId, score);
//            Cv2.PutText(img, label, new Point(xMin, yMin - 10), HersheyFonts.HersheySimplex, 0.5, Scalar.Green, 2);
//        }

//        Cv2.ImWrite(outputImagePath, img);
//    }

//    static string GetLabel(int classId, float score)
//    {
//        return classId switch
//        {
//            1 => $"Person: {score:P2}",
//            43 => $"Knife: {score:P2}",
//            37 => $"Gun: {score:P2}",
//            _ => $"Unknown: {score:P2}"
//        };
//    }
//}
