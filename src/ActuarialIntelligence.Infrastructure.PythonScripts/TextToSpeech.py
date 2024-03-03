
import pyttsx3
import socketio

# Connect to PSI server
sio = socketio.Client()
sio.connect('http://localhost:6011')

def speak_text_from_file(file_path):
    with open(file_path, 'r') as file:
        text = file.read()
        speak_text(text)

def speak_text(text):
    engine = pyttsx3.init()
    engine.say(text)
    engine.runAndWait()
    sio.emit('vowel', text)  # Emit the text to the PSI server

# Example usage: Speak text from a file
file_path = 'C:\\Users\\Rajah\\Documents\\Test Data\\TextScripts\\input.txt'  # Path to your text file
speak_text_from_file(file_path)