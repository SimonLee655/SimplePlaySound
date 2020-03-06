using System;
using System.Threading;
using NAudio.Wave;
using System.IO;
namespace playsoundcore
{
    class Program
    {
        static void Main(string[] args)
        {
            var cultureInfo = new System.Globalization.CultureInfo("zh-TW");
            foreach (var fileName in Directory.GetFiles(".\\"))
            {
                if (Path.GetExtension(fileName).ToLower(cultureInfo)
                    .Equals(".mp3", StringComparison.OrdinalIgnoreCase))
                {
                    PlaySound(fileName);
                }
            }
        }
        static void PlaySound(string fileName)
        {
            try
            {
                using (var audioFile = new AudioFileReader(fileName))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception Filename: {fileName}");
                Console.WriteLine($"Exception Message: {e.Message}");
            }
        }
    }
}