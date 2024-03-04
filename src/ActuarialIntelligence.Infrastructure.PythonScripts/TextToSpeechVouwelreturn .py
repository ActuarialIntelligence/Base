import pyttsx3

def speak_text_with_vowels_from_file(file_path):
    engine = pyttsx3.init()

    # Adjust settings to approximate Cartman's voice
    engine.setProperty('rate', 150)  # Adjust speech rate (words per minute)
    engine.setProperty('pitch', 50)  # Adjust speech pitch (in Hz)
    engine.setProperty('volume', 1.0)  # Adjust speech volume (from 0.0 to 1.0)

    # Read text from input file
    with open(file_path, 'r') as file:
        text = file.read()

    # Speak the whole words
    engine.say(text)
    engine.runAndWait()

    # Print vowels from the whole words
    vowels = ['a', 'e', 'i', 'o', 'u']
    for char in text:
        if char.lower() in vowels:
            print("Vowel:", char)

# Example usage: Speak the words from a text file and print vowels
file_path = 'C:\\Users\\Rajah\\Documents\\Test Data\\TextScripts\\input.txt'  # Path to your text file
speak_text_with_vowels_from_file(file_path)


