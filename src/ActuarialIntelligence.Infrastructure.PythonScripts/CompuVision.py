import cv2

imagePath = 'C:\\Users\\User\\Desktop\\MachineLearning\\12 FaceDetection\\image3.jpg'
cascadeClassifierPath = 'C:\\Users\\User\\Desktop\\haarcascade_frontalface_alt.xml'

cascadeClassifier = cv2.CascadeClassifier(cascadeClassifierPath)
image = cv2.imread(imagePath)
grayImage = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)

detectedFaces = cascadeClassifier.detectMultiScale(grayImage,  scaleFactor=1.1, minNeighbors=10, minSize=(30, 30))

for(x, y, width, height) in detectedFaces: cv2.rectangle(image, (x, y), (x+width, y+height), (0, 0, 255), 10)
cv2.imwrite('result.jpg', image)


face_cascade = cv2.CascadeClassifier('C:/Users/N/Desktop/haarcascade_frontalface_default.xml')
faces = face_cascade.detectMultiScale(grayImage)
print(type(faces))
print(faces)
printfaces(shape)
print("Number of faces detected: " + str(faces.shape[0]))
