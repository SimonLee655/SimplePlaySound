using System;
using System.Threading;
using NAudio.Wave;
using System.IO;
namespace playsound
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = System.IO.Directory.GetFiles(".\\");
            foreach (var fileName in files)
            {
                if (Path.GetExtension(fileName).ToLower().Equals(".mp3"))
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