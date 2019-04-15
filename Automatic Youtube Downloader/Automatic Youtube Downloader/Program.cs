using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Automatic_Youtube_Downloader
{
    class Program
    {
        private static int counter = 0;
        private static string[] sequence = new string[] { "[   .   ]", "[  ...  ]", "[ .. .. ]", "[..   ..]", "[.     .]" };
        private static List<string> urls = new List<string>();
        private static readonly string[] filesCheck = new[] { "avcodec-58.dll", "avdevice-58.dll", "avfilter-7.dll", "avformat-58.dll", "avutil-56.dll", "ffmpeg.exe", "ffprobe.exe", "postproc-55.dll", "swresample-3.dll", "swscale-5.dll" };
        private static readonly string urlVideoPath = "urlsVideo.txt";
        private static readonly string urlAudioPath = "urlsAudio.txt";

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
                                  "[2]> Audio");
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
        static void Turn()
        {
            counter++;

            if (counter >= sequence.Length)
                counter = 0;

            Console.Write("\n" + sequence[counter]);
            Console.SetCursorPosition(Console.CursorLeft - sequence[counter].Length, Console.CursorTop - 1);
        }

        static void IsRunning(Process status, bool animation)
        {
            counter = 0;
            while (!status.HasExited)
            {
                if (animation == true)
                {
                    Turn();
                }
                Thread.Sleep(250);
            }
        }

        static void FileCheck()
        {
            //Python check
            if (!File.Exists("/Windows/py.exe"))
            {
                Console.WriteLine("Puudu on vajalik fail /Windows/py.exe");
                Console.WriteLine("Installi endale Python 3");
                Process.Start("https://www.python.org/downloads/");
                Console.ReadKey();
                Environment.Exit(0);
            }
            foreach (string s in filesCheck)
            {
                if (!File.Exists("data/" + s))
                {
                    Console.WriteLine("Puudu on vajalik fail " + s);
                    Console.WriteLine("Programmi reinstallimine võib probleemi lahendada");
                }
            }
        }

        static Process ConsoleOutput(Process process, string fileName, string arguments)
        {
            process.StartInfo.FileName = fileName;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            return process;
        }

        static void UrlRead(string urlPath)
        {
            using (StreamReader reader = new StreamReader(urlPath))
            {
                while (!reader.EndOfStream)
                    urls.Add(reader.ReadLine());
                reader.Close();
            }
        }

        /// <summary>
        /// Audio Failideks
        /// </summary>
        static void Audio()
        {
            DownloadSetup(urlAudioPath);

            Console.Clear();
            foreach (var VARIABLE in urls)
            {
                Console.WriteLine("{0} / {1} faili", urls.IndexOf(VARIABLE) + 1, urls.Count);
                IsRunning(ConsoleOutput(new Process(), Path.GetFullPath("youtube-dl.exe"), " --config-location dl-Audio.txt " + VARIABLE), true);

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
            foreach (var VARIABLE in urls)
            {
                Console.WriteLine("{0} / {1} faili", urls.IndexOf(VARIABLE) + 1, urls.Count);
                IsRunning(ConsoleOutput(new Process(), Path.GetFullPath("youtube-dl.exe"), " --config-location dl-Video.txt " + VARIABLE), true);
            }
            Console.Title = "Automatic Youtube V/A Downloader";
            OpenFolderForms("Video");
        }

        static void DownloadSetup(string path)
        {
            Console.Clear();
            Console.WriteLine("Sisesta text faili URL-id reakaupa,\n" +
                              "Salvesta ja sule fail kui oled valmis allalaadima.\n" +
                              "Kui ei taha midagi alla laadida, siis pane konsool ennem kinni.");
            //Ei jätka kuni failid pannakse kinni
            IsRunning(Process.Start(path), false);
            //Loeb sisestatud URL'id
            UrlRead(path);
            Console.Clear();
        }

        static void OpenFolderForms(string format)
        {
            DialogResult ans = MessageBox.Show("Kas sa soovid vaadata allalaaditud faile?", "Kausta avamine", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification);
            if (ans == DialogResult.Yes)
                if (format == "Audio")
                    Process.Start("explorer.exe", "/open," + Path.GetFullPath("Downloaded files/Audio/"));
                else if (format == "Video")
                    Process.Start("explorer.exe", "/open," + Path.GetFullPath("Downloaded files/Video/"));
        }
    }
}
