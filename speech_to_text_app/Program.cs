using System;
using System.Speech.Recognition;

namespace SpeechToTextConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of SpeechRecognitionEngine
            using (SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine())
            {
                // Configure the input to the recognizer
                recognizer.SetInputToDefaultAudioDevice();

                // Create and load a dictation grammar
                recognizer.LoadGrammar(new DictationGrammar());

                // Attach event handlers for recognizing speech
                recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

                // Start asynchronous speech recognition
                recognizer.RecognizeAsync(RecognizeMode.Multiple);

                // Keep the console window open
                Console.WriteLine("Speak now. Press ENTER to exit after speaking...");
                Console.ReadLine();

                // Stop recognizing
                recognizer.RecognizeAsyncStop();
            }
        }

        // Handle the SpeechRecognized event
        static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine("Recognized text: " + e.Result.Text);
        }
    }
}
