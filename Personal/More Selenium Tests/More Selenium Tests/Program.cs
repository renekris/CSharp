using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace More_Selenium_Tests
{
    class Program
    {
        static void ChildThread()
        {
            while (true)
            {
                try
                {
                    Console.Write("\r{0}/10", Counter);
                }
                catch (Exception)
                {

                }
            }
        }

        static Thread refThread = new Thread(ChildThread);
        private static int Counter { get; set; }
        static void Main(string[] args)
        {
            Counter = 0;
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications");
            IWebDriver driver = new ChromeDriver(Directory.GetCurrentDirectory(), options);
            driver.Navigate().GoToUrl(@"http://testing-ground.scraping.pro/login");

            refThread.Start();

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    driver.FindElement(By.XPath("//input[@id='usr']")).Click();
                    driver.FindElement(By.XPath("//input[@id='usr']")).SendKeys("admin");

                    driver.FindElement(By.XPath("//input[@id='pwd']")).Click();
                    driver.FindElement(By.XPath("//input[@id='pwd']")).SendKeys("12345");
                    driver.FindElement(By.XPath("//input[@id='pwd']")).Submit();
                    driver.FindElement(By.XPath("//a[contains(text(),'<< GO BACK')]")).Click();
                }
                catch (Exception)
                {
                    driver.FindElement(By.XPath("//a[contains(text(),'<< GO BACK')]")).Click();
                }
                Counter++;
            }
            Console.WriteLine("\nLoops done");
            driver.Quit();
            Environment.Exit(0);
            Thread.Sleep(2000);

        }
    }
}
