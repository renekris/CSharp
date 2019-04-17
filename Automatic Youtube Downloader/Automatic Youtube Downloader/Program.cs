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

        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    MainMethodSetup();
                    Console.WriteLine("[1]> Video\tFormaat:[{0}]", Settings.Default.defaultVideoFormat.ToUpper());
                    Console.WriteLine("[2]> Audio\tFormaat:[{0}]", Settings.Default.defaultAudioFormat.ToUpper());
                    Console.WriteLine("[3]> Seaded\n");
                    Console.WriteLine("[4]> Ava Meedia Kaust");

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
                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:
                            Process.Start("explorer.exe", "/open," + Path.GetFullPath("Downloaded files/"));
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("\n\nPalun teata veast. Email: renekrispohlak@gmail.com | Github: github.com/renekris");
                Console.ReadKey();
                throw;
            }
        }

        static void Settings_()
        {
            while (true)
            {
                Settings.Default.Save();
                string[] videoFormatStringsArray = new[] { "mp4", "flv", "ogg", "webm", "mkv", "avi" };
                string[] audioFormatStringsArray = new[] { "mp3", "flac", "aac", "m4a", "opus", "wav" };

                Console.Clear();
                Console.WriteLine("[1]> Muuda Video Formaati >{0}<\t[MP4, FLV, OGG, WEBM, MKV, AVI]", String.Format("[{0}]", Settings.Default.defaultVideoFormat.ToUpper()));
                Console.WriteLine("[2]> Muuda Audio Formaati >{0}<\t[MP3, FLAC, AAC, M4A, OPUS, WAV]", String.Format("[{0}]", Settings.Default.defaultAudioFormat.ToUpper()));
                Console.WriteLine("[3]> Tagasi Vaikimisi Väärtustele\t[MP4 & MP3]");
                Console.WriteLine("\n\n\n[ESC]> Lahku");

                //text painting goes here
                //Console.ForegroundColor = ConsoleColor.DarkRed;
                //Console.SetCursorPosition(41, 0);
                //Console.WriteLine("MP4");
                //Console.ResetColor();


                ConsoleKey press = Console.ReadKey().Key;
                switch (press)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Settings.Default.defaultVideoFormat = GetNextInArray(videoFormatStringsArray, Settings.Default.defaultVideoFormat);
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Settings.Default.defaultAudioFormat = GetNextInArray(audioFormatStringsArray, Settings.Default.defaultAudioFormat);
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Settings.Default.Reset();
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Escape:
                    case ConsoleKey.Backspace:
                    case ConsoleKey.Delete:
                        return;
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
                IsRunning(ConsoleOutput(new Process(), Path.GetFullPath("youtube-dl.exe"), " --config-location dl-Audio.conf " + ExportFormat("AUDIO") + " " + URL), true);
            }
            SetTitle();
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
                IsRunning(ConsoleOutput(new Process(), Path.GetFullPath("youtube-dl.exe"), " --config-location dl-Video.conf " + ExportFormat("VIDEO") + " " + URL), true);
            }
            SetTitle();
            OpenFolderForms("Video");
        }
    }
}
