import cv2

imagePath = 'C:\\Users\\rajiyer\\Documents\\Test Data\\OLD_CODE\\FaceDetection\\Faces.jfif'
cascadeClassifierPath = 'C:\\Users\\rajiyer\\Documents\\Test Data\\OLD_CODE\\FaceDetection\\haarcascade_frontalface_alt.xml'

cascadeClassifier = cv2.CascadeClassifier(cascadeClassifierPath)
image = cv2.imread(imagePath)
grayImage = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)

detectedFaces = cascadeClassifier.detectMultiScale(grayImage, scaleFactor=1.1, minNeighbors=10, minSize=(30, 30))

for (x, y, width, height) in detectedFaces: cv2.rectangle(image, (x, y), (x + width, y + height), (0, 0, 255), 10)
cv2.imwrite('result.jpg', image)

face_cascade = cv2.CascadeClassifier('C:/Users/rajiyer/Documents/Test Data/OLD_CODE/FaceDetection/haarcascade_frontalface_alt.xml')
faces = face_cascade.detectMultiScale(grayImage)
print(type(faces))
print(faces)

print("Number of faces detected: " + str(faces.shape[0]))


