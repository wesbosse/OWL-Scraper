using System;
using System.Linq;
using HtmlAgilityPack;
using ScrapySharp.Html.Parsing;
using ScrapySharp.Core;
using ScrapySharp.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OwlScraper
{
    class mainClass
    {
        public string read()
        {
            try
            {
                IWebDriver driver = new ChromeDriver();
                driver.Url = "http://www.oddsportal.com/esports/usa/overwatch-overwatch-league/results/";
                String PageSource = driver.PageSource;

                return PageSource;
            }
            catch (Exception e)
            {
                //if the page load does not work, print the error message and return nothing
                Console.WriteLine("Error: " + e.ToString());
                return null;
            }
        }

        public static void Main(string[] args)
        {
            //instantiate our class
            mainClass mainClass = new mainClass();

            HtmlDocument htmlWeb = new HtmlDocument();

            //use our newly defined read function to grab the html
            htmlWeb.LoadHtml(mainClass.read());

            Array tableRows = htmlWeb.DocumentNode.CssSelect("table#tournamentTable tr").ToArray();

            foreach (var item in tableRows)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
