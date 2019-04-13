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

namespace Jumpcutter_made_easier
{
    class Program
    {
        private static string urlPath = "URLS.txt";
        private static List<string> URLS = new List<string>();

        static void IsRunning(Process status)
        {
            while (!status.HasExited)
            {
                Thread.Sleep(250);
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            //Teeb faili kui see puudub
            if (!File.Exists(urlPath))
            {
                File.Create(urlPath).Dispose();
            }
            Console.WriteLine("Sisesta text faili URL-id reakaupa,\n" +
                              "Salvesta ja sule fail kui oled valmis allalaadima");
            //Ei jätka kuni fail pannakse kinni
            IsRunning(Process.Start(urlPath));
            IsRunning(Process.Start(@"pip3", @"install pytube"));
            IsRunning(Process.Start(@"pip3", @"install youtube-dl"));

            //Loeb sisestatud URL'id
            using (StreamReader reader = new StreamReader(urlPath))
            {
                while (!reader.EndOfStream)
                {
                    URLS.Add(reader.ReadLine());
                }
            }

            //Kontrollib korra veel faili olemasolu
            if (File.Exists(urlPath))
            {
                foreach (var VARIABLE in URLS)
                {
                    IsRunning(Process.Start(@"youtube-video.py", @"-url " + VARIABLE));
                }
                Console.WriteLine("Kõik videod alla laetud!");
            }

            Console.WriteLine("Fail on kustutatud");
        }
    }
}
