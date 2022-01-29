using System;
using System.Speech.Synthesis;
using System.Threading;
using System.Threading.Tasks;

namespace ItsTeaTime
{
    internal class Program
    {
        private const int FiveMinutesInMilliseconds = 1 * 60 * 1000;

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

            RepeatReminderAfterDelay();

            Console.ReadLine();          
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

        private async static Task RepeatReminderAfterDelay()
        {
            var delayTask = Task.Delay(60 * 1000);

            await delayTask;

            var synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();
            synth.Speak("Your tea is getting colder, sir!");
        }
    }
}
