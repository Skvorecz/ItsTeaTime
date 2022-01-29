using System;
using System.Speech.Synthesis;
using System.Threading;
using System.Threading.Tasks;

namespace ItsTeaTime
{
    internal class Program
    {
        private const int FiveMinutesInMilliseconds = 5 * 60 * 1000;

        static void Main(string[] args)
        {
            Console.WriteLine($"I'm glad you decided to take some tea {GetTimeOfDay()}!");
            Task.Delay(FiveMinutesInMilliseconds).Wait();
                        
            Console.Beep();
            Task.Delay(500).Wait();

            Console.Beep();
            Task.Delay(500).Wait();

            Console.Beep();
            Task.Delay(500).Wait();

            var synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();
            synth.Speak("This is tea time!");

            Console.Beep();
        }

        private static string GetTimeOfDay()
        {
            var currentHour = DateTime.Now.Hour;

            if(currentHour >= 5 && currentHour < 12)
            {
                return "this morning";
            }

            if(currentHour >= 12 && currentHour < 19)
            {
                return "today";
            }

            if(currentHour >= 19 && currentHour < 23)
            {
                return "this evening";
            }

            return "tonight";
            
        }


    }
}
