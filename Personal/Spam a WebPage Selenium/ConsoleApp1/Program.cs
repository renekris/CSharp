using System;
using System.IO;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleApp1
{
    class Program
    {
        public static void CallToChildThread()
        {
            while (Console.ReadKey().Key != ConsoleKey.Sleep)
            {
                Console.WriteLine("Closing!");
                driver.Quit();
                driver2.Quit();
                driver3.Quit();
                driver4.Quit();
                Environment.Exit(0);
            }
        }

        public static void Driver1()
        {
            for (int i = 0; i < amount; i++)
            {
                driver.Navigate().GoToUrl(url);
            }
        }
        public static void Driver2()
        {
            for (int i = 0; i < amount; i++)
            {
                driver2.Navigate().GoToUrl(url);
            }
        }
        public static void Driver3()
        {
            for (int i = 0; i < amount; i++)
            {
                driver3.Navigate().GoToUrl(url);
            }
        }
        public static void Driver4()
        {
            for (int i = 0; i < amount; i++)
            {
                driver4.Navigate().GoToUrl(url);
            }
        }

        public static void ThreadStart()
        {
            ThreadStart childref = new ThreadStart(CallToChildThread);
            Thread childThread = new Thread(childref);
            childThread.Start();
        }

        private static int amount = 200;
        static string url = "http://phpcenter.eu/kiirustest/?test=1";
        public static IWebDriver driver = new ChromeDriver(Directory.GetCurrentDirectory());
        public static IWebDriver driver2 = new ChromeDriver(Directory.GetCurrentDirectory());
        public static IWebDriver driver3 = new ChromeDriver(Directory.GetCurrentDirectory());
        public static IWebDriver driver4 = new ChromeDriver(Directory.GetCurrentDirectory());
        
        static void Main(string[] args)
        {
            ThreadStart();
            ThreadStart childref1 = new ThreadStart(Driver1);
            Thread childThread1 = new Thread(childref1);
            childThread1.Start();

            ThreadStart childref2 = new ThreadStart(Driver2);
            Thread childThread2 = new Thread(childref2);
            childThread2.Start();

            ThreadStart childref3 = new ThreadStart(Driver3);
            Thread childThread3 = new Thread(childref3);
            childThread3.Start();

            ThreadStart childref4 = new ThreadStart(Driver4);
            Thread childThread4 = new Thread(childref4);
            childThread4.Start();
            //driver.FindElement(By.XPath("/html/body/input")).Click();
        }
    }
}
