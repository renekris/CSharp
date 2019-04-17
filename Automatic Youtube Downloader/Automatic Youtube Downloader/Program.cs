using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Automatic_Youtube_Downloader.Properties;

namespace Automatic_Youtube_Downloader
{
    class Program : MLib
    {
        static string formatVideo = "";
        static string formatAudio = "--audio-format mp3";
        static void Main(string[] args)
        {

            try
            {
                Console.Title = "Automatic Youtube V/A Downloader";
                Console.OutputEncoding = Encoding.Unicode;
                Console.InputEncoding = Encoding.Unicode;
                //Kontrollib failide olemasolu
                FileCheck();

                if (!File.Exists(urlAudioPath))
                    File.Create(urlAudioPath).Dispose();
                if (!File.Exists(urlVideoPath))
                    File.Create(urlVideoPath).Dispose();

                Console.WriteLine("[1]> Video\n" +
                                  "[2]> Audio\n" +
                                  "[3]> Seaded");
                ConsoleKey press = Console.ReadKey().Key;
                switch (press)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Video();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Audio();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Settings_();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("\n\nPalun teata veast. renekrispohlak@gmail.com | github.com/renekris");
                Console.ReadKey();
                throw;
            }
        }
        
        static void Settings_()
        {
            while (true)
            {

                Settings.Default.Save();
                string[] audioFormatStringsArray = new[] { "mp3", "flac", "aac", "m4a", "opus", "vorbis", "wav" };
                string[] videoFormatStringsArray = new[] { "mp4", "flv", "ogg", "webm", "mkv", "avi" };

                Console.Clear();
                Console.WriteLine("[1]> Muuda Video Formaati{0}\n", String.Format("[{0}]", Settings.Default.defaultVideoFormat.ToUpper()));
                Console.WriteLine("[2]> Muuda Audio Formaati{0}", String.Format("[{0}]", Settings.Default.defaultAudioFormat.ToUpper()));
                ConsoleKey press = Console.ReadKey().Key;
                switch (press)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        //Settings.Default.defaultVideoFormat = audioFormatStringsArray[1];
                        Settings.Default.defaultVideoFormat = GetNextInArray(audioFormatStringsArray, Settings.Default.defaultVideoFormat);
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Settings.Default.defaultAudioFormat = GetNextInArray(videoFormatStringsArray, Settings.Default.defaultAudioFormat);
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Escape:
                    case ConsoleKey.Backspace:

                        break;
                    default:
                        break;
                }
            }
        }


        /// <summary>
        /// Audio Failideks
        /// </summary>
        static void Audio()
        {
            DownloadSetup(urlAudioPath);

            Console.Clear();
            foreach (var URL in urls)
            {
                Console.WriteLine("{0} / {1} faili", urls.IndexOf(URL) + 1, urls.Count);
                IsRunning(ConsoleOutput(new Process(), Path.GetFullPath("youtube-dl.exe"), " --config-location dl-Audio.conf " + formatAudio + " " + URL), true);
            }
            Console.Title = "Automatic Youtube V/A Downloader";
            OpenFolderForms("Audio");
        }

        /// <summary>
        /// Video Failideks
        /// </summary>
        static void Video()
        {
            DownloadSetup(urlVideoPath);

            //Kontrollib korra veel faili olemasolu
            foreach (var URL in urls)
            {
                Console.WriteLine("{0} / {1} faili", urls.IndexOf(URL) + 1, urls.Count);
                IsRunning(ConsoleOutput(new Process(), Path.GetFullPath("youtube-dl.exe"), " --config-location dl-Video.conf " + formatVideo + " " + URL), true);
            }
            Console.Title = "Automatic Youtube V/A Downloader";
            OpenFolderForms("Video");
        }
    }
}
