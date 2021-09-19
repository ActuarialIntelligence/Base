using ActuarialIntelligence.Domain.ConnectedInstruction;
using Domain;
using Domain.ObservationObjects;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace testObject
{
    class Program
    {
        static void Main(string[] args)
        {
            bool DonotLoadGrid = true;
            var grid = new List<IList<double>>();
            if (!DonotLoadGrid)
            {
                Console.WriteLine("Loading Stream: " + DateTime.Now.ToString());
                var sr = new StreamReader(@"C:\data\table.csv");

                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var fieldValues = line.Split(',');
                    var fields = new List<double>();
                    var rdm = new Random(100000);
                    foreach (var field in fieldValues)
                    {
                        var res = 0d;
                        var add = double.TryParse(field, out res) == true ? res : rdm.NextDouble();
                        fields.Add(add);
                    }
                    grid.Add(fields);
                }
                Console.WriteLine("Grid loaded successfully!! " + DateTime.Now.ToString());
            }
            var keepProcessing = true;
            while (keepProcessing)
            {
                Console.WriteLine(DateTime.Now.ToString());
                Console.WriteLine("Enter Expression:");
                var expression = Console.ReadLine();
                if (expression.ToLower() == "exit")
                {
                    keepProcessing = false;
                }
                else
                {
                    try
                    {
                        if(expression.Equals("zspread"))
                        {
                            var result = ConnectedInstruction.GetZSpread(grid,3,503);
                        }
                        if (expression.Substring(0, 19).ToLower().Equals("logisticregression "))
                        {
                            keepProcessing = true;
                            var paths = expression.Split(' '); 
                            #region Python
                                var script =@"
import pandas as pd
from sklearn.linear_model import LogisticRegression
from sklearn.cross_validation import train_test_split
from sklearn.metrics import confusion_matrix
from sklearn.metrics import accuracy_score

creditData = pd.read_csv("+paths[1]+@")

print(creditData.head())
print(creditData.describe())
print(creditData.corr())

features = creditData[['income', 'age', 'loan']]
target = creditData.default

feature_train, feature_test, target_train, target_test = train_test_split(features, target, test_size = 0.3)

model = LogisticRegression()
model.fit = model.fit(feature_train, target_train)
predictions = model.fit.predict(feature_test)

print(confusion_matrix(target_test, predictions))
print(accuracy_score(target_test, predictions))
";
                            var sw = new StreamWriter(@"c:\data\logistic.py");
                            sw.Write(script);
                            sw.Close();
                            #endregion
                            ProcessStartInfo start = new ProcessStartInfo();
                            Console.WriteLine("Starting Python Engine...");
                            start.FileName = @"C:\Users\rajiyer\PycharmProjects\TestPlot\venv\Scripts\python.exe";
                            start.Arguments = string.Format("{0} {1}", @"c:\data\logistic.py", args);
                            start.UseShellExecute = false;
                            start.RedirectStandardOutput = true;
                            Console.WriteLine("Starting Process..."+ DateTime.Now.ToString());
                            using (Process process = Process.Start(start))
                            {
                                using (StreamReader reader = process.StandardOutput)
                                {
                                    string result = reader.ReadToEnd();
                                    Console.Write(result);
                                }
                            }
                            Console.WriteLine("Process Succeeded..." + DateTime.Now.ToString());
                        }
                        if(expression.Substring(0,12) == "videoanalyse")
                        {
                            #region python
                            var python = @"
from keras.preprocessing.image import img_to_array
import imutils
import cv2
from keras.models import load_model
import numpy as np
import geocoder
#import mysql.connector as con

#mydb = con.connect(
#  host=""localhost"",
#  user=""yourusername"",
#  passwd=""yourpassword"",
# database=""mydatabase""
#)
#mycursor = mydb.cursor()

g = geocoder.ip('me')

# parameters for loading data and images
detection_model_path = 'C:\\Users\\rajiyer\\Documents\\Test Data\\Sentiment Analysis\\Emotion-recognition-master\\haarcascade_files\\haarcascade_frontalface_default.xml'
emotion_model_path = 'C:\\Users\\rajiyer\\Documents\\Test Data\\Sentiment Analysis\\Emotion-recognition-master\\models\\_mini_XCEPTION.102-0.66.hdf5'

# hyper-parameters for bounding boxes shape
# loading models
face_detection = cv2.CascadeClassifier(detection_model_path)
emotion_classifier = load_model(emotion_model_path, compile = False)
EMOTIONS = [""angry"", ""disgust"", ""scared"", ""happy"", ""sad"", ""surprised"",
""neutral""]


# feelings_faces = []
# for index, emotion in enumerate(EMOTIONS):
# feelings_faces.append(cv2.imread('emojis/' + emotion + '.png', -1))

# starting video streaming
cv2.namedWindow('your_face')
camera = cv2.VideoCapture(0)
f = open(""C:\\Users\\rajiyer\\Documents\\Test Data\\Probability.txt"", ""a+"")

while True:
frame = camera.read()[1]
#reading the frame
frame = imutils.resize(frame, width = 300)
gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
faces = face_detection.detectMultiScale(gray, scaleFactor = 1.1, minNeighbors = 5, minSize = (30, 30), flags = cv2.CASCADE_SCALE_IMAGE)


canvas = np.zeros((250, 300, 3), dtype = ""uint8"")
frameClone = frame.copy()
if len(faces) > 0:
faces = sorted(faces, reverse = True,
key = lambda x: (x[2] - x[0]) * (x[3] - x[1]))[0]
(fX, fY, fW, fH) = faces
# Extract the ROI of the face from the grayscale image, resize it to a fixed 28x28 pixels, and then prepare
# the ROI for classification via the CNN
roi = gray[fY: fY + fH, fX: fX + fW]
roi = cv2.resize(roi, (64, 64))
roi = roi.astype(""float"") / 255.0
roi = img_to_array(roi)
roi = np.expand_dims(roi, axis = 0)



preds = emotion_classifier.predict(roi)[0]
emotion_probability = np.max(preds)
label = EMOTIONS[preds.argmax()]
else: continue



for (i, (emotion, prob)) in enumerate(zip(EMOTIONS, preds)):
# construct the label text
text = ""{}: {:.2f}%"".format(emotion, prob * 100)
#sql = ""INSERT INTO predData (Metadata, Probability) VALUES (%s, %s)""
#val = (""Meta"", prob * 100)
f.write(text)
#str1 = ''.join(str(e) for e in g.latlng)
#f.write(str1)
#mycursor.execute(sql, val)
#mydb.commit()
# draw the label + probability bar on the canvas
# emoji_face = feelings_faces[np.argmax(preds)]

                
w = int(prob * 300)
cv2.rectangle(canvas, (7, (i * 35) + 5),
(w, (i * 35) + 35), (0, 0, 255), -1)
cv2.putText(canvas, text, (10, (i * 35) + 23),
cv2.FONT_HERSHEY_SIMPLEX, 0.45,
(255, 255, 255), 2)
cv2.putText(frameClone, label, (fX, fY - 10),
cv2.FONT_HERSHEY_SIMPLEX, 0.45, (0, 0, 255), 2)
cv2.rectangle(frameClone, (fX, fY), (fX + fW, fY + fH),
(0, 0, 255), 2)


#    for c in range(0, 3):
#        frame[200:320, 10:130, c] = emoji_face[:, :, c] * \
#        (emoji_face[:, :, 3] / 255.0) + frame[200:320,
#        10:130, c] * (1.0 - emoji_face[:, :, 3] / 255.0)


cv2.imshow('your_face', frameClone)
cv2.imshow(""Probabilities"", canvas)
if cv2.waitKey(1) & 0xFF == ord('q'):
break

camera.release()
cv2.destroyAllWindows()
";
                            var sw = new StreamWriter(@"c:\data\face.py");
                            sw.Write(python);
                            sw.Close();
                            #endregion
                            ProcessStartInfo start = new ProcessStartInfo();
                            Console.WriteLine("Starting Python Engine...");
                            start.FileName = @"C:\Users\rajiyer\PycharmProjects\TestPlot\venv\Scripts\python.exe";
                            start.Arguments = string.Format("{0} {1}", @"c:\data\face.py", args);
                            start.UseShellExecute = false;
                            start.RedirectStandardOutput = true;
                            Console.WriteLine("Starting Process..." + DateTime.Now.ToString());
                            using (Process process = Process.Start(start))
                            {
                                using (StreamReader reader = process.StandardOutput)
                                {
                                    string result = reader.ReadToEnd();
                                    Console.Write(result);
                                }
                            }
                            Console.WriteLine("Process Succeeded..." + DateTime.Now.ToString());
                        }
                        if (expression.Substring(0,12).ToLower().Equals("kaplanmeier "))
                        {
                            keepProcessing = true;
                            var columnsOfconcern = expression.Split(' ');
                            Console.WriteLine("Preparing...");
                            var observations = new List<PairedObservation>();
                            var ca = GetColumn(grid,int.Parse(columnsOfconcern[1]));
                            var cb = GetColumn(grid, int.Parse(columnsOfconcern[2]));
                            var cc = GetColumn(grid, int.Parse(columnsOfconcern[3]));
                            for(int i=0;i<ca.Count;i++)
                            {
                                observations.Add(new PairedObservation((decimal)ca[i], (decimal)cb[i], (decimal)cc[i]));
                            }
                            var kp = new KaplanMeier(observations);
                        }
                        if (expression.Equals("write"))
                        {
                            keepProcessing = true;
                            ConnectedInstruction.WritetoCsvu(grid, @"c:\data\temp.csv");
                        }
                        if (expression.Substring(0, 9) == "getvalue(")
                        {
                            keepProcessing = true;
                            Regex r = new Regex(@"\(([^()]+)\)*");
                            var res = r.Match(expression);
                            var val = res.Value.Split(',');
                            try
                            {
                                var gridVal = grid[int.Parse(val[0].Replace("(", "").Replace(")", ""))]
                                    [int.Parse(val[1].Replace("(", "").Replace(")", ""))];
                                Console.WriteLine(gridVal.ToString() + "\n");
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine("Hmmm,... apologies, can't seem to find that within range...");
                            }
                        }
                        else
                        {
                            keepProcessing = true;
                            Console.WriteLine("Process Begin:" + DateTime.Now.ToString());
                            var result = ConnectedInstruction.ParseExpressionAndRunAgainstInMemmoryModel(grid, expression);
                            Console.WriteLine("Process Ended:" + DateTime.Now.ToString());
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {

                    }
                }
            }
        }

        public static IList<double> GetColumn(IList<IList<double>> gridValues, int column)
        {
            var columnValues = new List<double>();
            foreach (var row in gridValues)
            {
                columnValues.Add(row[column]);
            }
            return columnValues;
        }
    }
}
