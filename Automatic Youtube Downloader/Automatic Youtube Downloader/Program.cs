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
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Automatic_Youtube_Downloader
{
    class Program
    {
        private static string[] pythonPackages = new[] { "pytube", "youtube-dl" };
        private static Regex removeNum = new Regex(@"[0-9=./\()*&^%$#@!]+");
        private static List<string> urls = new List<string>();
        private static string[] filesCheck = new[] { "youtube-audio.py", "youtube-video.py", "/Windows/py.exe" };
        private static string urlPath = "urls.txt";

        static void IsRunning(Process status)
        {
            while (!status.HasExited)
            {
                Thread.Sleep(250);
            }
        }

        static void FileCheck()
        {
            foreach (string s in filesCheck)
            {
                if (!File.Exists(s))
                {
                    Console.WriteLine("Puudu on vajalik fail {0}", s);
                    if (s == "/Windows/py.exe")
                    {
                        Console.WriteLine("Installi endale Python 3");
                        Process.Start("https://www.python.org/downloads/");
                    }
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
        }

        static Process ConsoleOutput(Process process, string fileName, string arguments)
        {
            process.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            process.StartInfo.FileName = fileName;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            return process;
        }

        static void Main(string[] args)
        {
            try
            {
                Console.Title = "Automatic Youtube V/A Downloader";
                Console.OutputEncoding = Encoding.Unicode;
                Console.InputEncoding = Encoding.Unicode;
                //Kontrollib failide olemasolu

                FileCheck();
                //Teeb faili kui see puudub
                if (!File.Exists(urlPath))
                    File.Create(urlPath).Dispose();

                Console.WriteLine("Sisesta text faili URL-id reakaupa,\n" +
                                  "Salvesta ja sule fail kui oled valmis allalaadima");
                //Ei jätka kuni failid pannakse kinni
                IsRunning(Process.Start(urlPath));

                //Kontrollib kas õiged pythoni osad olemas
                Process pipFreeze = new Process();
                ConsoleOutput(pipFreeze, "py.exe", "-m pip freeze");

                List<string> pipFreezeList = new List<string>();
                pipFreezeList.Add(removeNum.Replace(pipFreeze.StandardOutput.ReadToEnd(), ""));
                foreach (var freeze in pipFreezeList)
                {
                    if (!pythonPackages.All(freeze.Contains))
                    {
                        IsRunning(Process.Start(@"py.exe", @"-m pip install pytube"));
                        IsRunning(Process.Start(@"py.exe", @"-m pip install youtube-dl"));
                    }
                }


                //Loeb sisestatud URL'id
                using (StreamReader reader = new StreamReader(urlPath))
                {
                    while (!reader.EndOfStream)
                        urls.Add(reader.ReadLine());
                    reader.Close();
                }

                //Kontrollib korra veel faili olemasolu
                if (File.Exists(urlPath))
                {
                    foreach (var VARIABLE in urls)
                    {
                        //Laeb videod alla
                        Console.WriteLine(urls.IndexOf(VARIABLE) + 1 + "/" + urls.Count);
                        IsRunning(Process.Start(@"py.exe", @"youtube-video.py --url " + VARIABLE));
                        Console.Clear();
                    }
                    Console.Clear();
                    Console.WriteLine("Kõik videod alla laetud!");
                    DialogResult ans = MessageBox.Show("Kas sa soovid vaadata allalaetud faile?", "Kausta avamine", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (ans == DialogResult.Yes)
                        Process.Start("explorer.exe", "/select," + Path.GetFullPath("Automatic Youtube Downloader.exe"));
                    else
                        Environment.Exit(0);
                }
                Environment.Exit(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
                throw;
            }
        }
    }
}
