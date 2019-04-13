using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Automatic_Youtube_Downloader
{
    class Program
    {
        private static string[] filesCheck = new[] { "youtube-audio.py", "youtube-video.py" };
        private static string urlPath = "URLS.txt";
        private static List<string> URLS = new List<string>();

        static void IsRunning(Process status)
        {
            while (!status.HasExited)
                Thread.Sleep(250);
        }
        static void Main(string[] args)
        {
            Console.Title = "Automatic Youtube V/A Downloader";
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            foreach (string s in filesCheck)
            {
                if (!File.Exists(s))
                    Console.WriteLine("Puudu on vajalik fail {0}", s);
            }
            //Teeb faili kui see puudub
            if (!File.Exists(urlPath))
                File.Create(urlPath).Dispose();

            Console.WriteLine("Sisesta text faili URL-id reakaupa,\n" +
                              "Salvesta ja sule fail kui oled valmis allalaadima");
            //Ei jätka kuni failid pannakse kinni
            IsRunning(Process.Start(urlPath));
            try
            {
                IsRunning(Process.Start(@"pip3", @"install pytube"));
                IsRunning(Process.Start(@"pip3", @"install youtube-dl"));
            }
            catch (Exception)
            {
                Console.WriteLine("Installi omale Python 3 ja pip 3");
            }

            //Loeb sisestatud URL'id
            using (StreamReader reader = new StreamReader(urlPath))
            {
                while (!reader.EndOfStream)
                    URLS.Add(reader.ReadLine());
            }

            //Kontrollib korra veel faili olemasolu
            if (File.Exists(urlPath))
            {
                foreach (var VARIABLE in URLS)
                {
                    //Laeb videod alla
                    IsRunning(Process.Start(@"youtube-video.py", @"-url " + VARIABLE));
                }
                Console.WriteLine("Kõik videod alla laetud!");
            }

            Console.WriteLine("Fail on kustutatud");
        }
    }
}
