
import pyttsx3

def speak_text_from_file(file_path):
    with open(file_path, 'r') as file:
        text = file.read()
        speak_text(text)

def speak_text(text):
    engine = pyttsx3.init()
    engine.connect('finished-utterance', on_finished)
    engine.startLoop(False)
    engine.say(text)
    engine.iterate()

def on_finished(status):
    if status == 'completed':
        print_vowels(current_text)

def print_vowels(text):
    vowels = [char for char in text if char.lower() in 'aeiou']
    print("Vowels in the text:")
    print(vowels)

# Example usage: Speak text from a file
file_path = 'C:\\Users\\Rajah\\Documents\\Test Data\\TextScripts\\input.txt'  # Path to your text file
current_text = ""
speak_text_from_file(file_path)
