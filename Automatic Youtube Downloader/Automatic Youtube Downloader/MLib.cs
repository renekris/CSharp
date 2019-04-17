using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automatic_Youtube_Downloader
{
    class MLib
    {
        internal static int counter = 0;
        internal static string[] sequence = new string[] { "[   .   ]", "[  ...  ]", "[ .. .. ]", "[..   ..]", "[.     .]" };
        internal static List<string> urls = new List<string>();
        internal static readonly string[] filesCheck = new[] { "avcodec-58.dll", "avdevice-58.dll", "avfilter-7.dll", "avformat-58.dll", "avutil-56.dll", "ffmpeg.exe", "ffprobe.exe", "postproc-55.dll", "swresample-3.dll", "swscale-5.dll" };
        internal static readonly string urlVideoPath = "urlsVideo.txt", urlAudioPath = "urlsAudio.txt";

        static void UrlRead(string urlPath)
        {
            using (StreamReader reader = new StreamReader(urlPath))
            {
                string URL;
                while (!reader.EndOfStream)
                {
                    URL = reader.ReadLine();
                    if (!URL.StartsWith("#") && !String.IsNullOrWhiteSpace(URL))
                        urls.Add(URL);
                }
            }
        }

        internal static void SetTitle()
        {
            Console.Title = "Automatic Youtube V/A Downloader - Renekris";
        }

        internal static void MainMethodSetup()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            urls.Clear();
            Console.Clear();
            SetTitle();
            FileCheck();
            if (!File.Exists(urlAudioPath))
                File.Create(urlAudioPath).Dispose();
            if (!File.Exists(urlVideoPath))
                File.Create(urlVideoPath).Dispose();
        }
        internal static void DownloadSetup(string path)
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
        internal static Process ConsoleOutput(Process process, string fileName, string arguments)
        {
            process.StartInfo.FileName = fileName;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            return process;
        }
        internal static void FileCheck()
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
        internal static void OpenFolderForms(string format)
        {
            DialogResult ans = MessageBox.Show("Kas sa soovid vaadata allalaaditud faile?", "Kausta avamine", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification);
            if (ans == DialogResult.Yes)
                if (format == "Audio")
                    Process.Start("explorer.exe", "/open," + Path.GetFullPath("Downloaded files/Audio/"));
                else if (format == "Video")
                    Process.Start("explorer.exe", "/open," + Path.GetFullPath("Downloaded files/Video/"));
        }
        internal static void IsRunning(Process status, bool animation)
        {
            counter = 0;
            while (!status.HasExited)
            {
                if (animation == true)
                    Turn();
                Thread.Sleep(250);
            }
        }
        internal static void Turn()
        {
            counter++;
            if (counter >= sequence.Length)
                counter = 0;

            Console.Write("\n\r" + sequence[counter]);
            Console.SetCursorPosition(Console.CursorLeft - sequence[counter].Length, Console.CursorTop - 1);
        }
        internal static string GetNextInArray(IList<string> items, string curr)
        {
            if (String.IsNullOrWhiteSpace(curr))
                return items[0];

            var index = items.IndexOf(curr);
            if (index == -1)
                return items[0];

            return items[(index + 1) % items.Count];
        }
    }
}
