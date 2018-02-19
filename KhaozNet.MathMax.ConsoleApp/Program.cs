using System;
using System.Threading;
using KhaozNet.MathMax.Data.Repository;
using KhaozNet.MathMax.Domain.Result;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace KhaozNet.MathMax.ConsoleApp
{
    class Program
    {
        private static string _webUrl;
        private static Random _random;
        private static bool _pretendToBeHuman;

        static void Main(string[] args)
        {
            _random = new Random();
            _pretendToBeHuman = false;
            _webUrl = @"https://mathmax.io/";
            Console.WriteLine($"Initializing for {_webUrl}");

            using (ChromeDriver driver = new ChromeDriver())
            {
                driver.Url = _webUrl;

                Console.WriteLine("Ready to go, choose a difficulty and after the countdown hit enter here");
                Console.ReadKey();

                int retries = 0;
                while (retries < 3)
                {
                    IWebElement option1;
                    IWebElement option2;
                    try
                    {
                        option1 = driver.FindElementById("opt1");
                        option2 = driver.FindElementById("opt2");
                    }
                    catch (Exception)
                    {
                        retries++;
                        continue;
                    }

                    if (string.IsNullOrEmpty(option1.Text))
                    {
                        retries++;
                        continue;
                    }
                    if (string.IsNullOrEmpty(option2.Text))
                    {
                        retries++;
                        continue;
                    }

                    Result<double> option1Result = CalculationHelper.EvaluateExpression(option1.Text);
                    if (option1Result.HasFailed)
                    {
                        Console.WriteLine($"Could not understand: {option1.Text}");
                        RandomClick(option1, option2);
                        continue;
                    }

                    Result<double> option2Result = CalculationHelper.EvaluateExpression(option2.Text);
                    if (option2Result.HasFailed)
                    {
                        Console.WriteLine($"Could not understand: {option2.Text}");
                        RandomClick(option1, option2);
                        continue;
                    }

                    Console.WriteLine($"{option1Result.Value} vs. {option2Result.Value}");
                    if (option1Result.Value == option2Result.Value)
                    {
                        RandomClick(option1, option2);
                    }
                    else if (option1Result.Value > option2Result.Value)
                    {
                        option1.Click();
                    }
                    else
                    {
                        option2.Click();
                    }

                    if (_pretendToBeHuman) PretendToBeHuman();
                }

                Console.WriteLine("Error occured trying to find the options");
                Console.ReadKey();
            }
        }
        

        private static void RandomClick(IWebElement option1, IWebElement option2)
        {
            int randomPercent = _random.Next(0, 100);
            if (randomPercent < 50)
            {
                option1.Click();
            }
            else
            {
                option2.Click();
            }
        }
        private static void PretendToBeHuman()
        {
            int waitTime = _random.Next(5, 15) * 100;
            Thread.Sleep(waitTime);
        }

    }
}
