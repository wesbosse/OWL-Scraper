using System;
using System.Linq;
using HtmlAgilityPack;
using ScrapySharp.Html.Parsing;
using ScrapySharp.Core;
using ScrapySharp.Extensions;

namespace OwlScraper
{
    class MainClass
    {
        public string read()
        {
            //instantiate the html parsing
            HtmlWeb htmlWeb = new HtmlWeb();
            try
            {
                //load the webpage with match info
                HtmlAgilityPack.HtmlDocument document = htmlWeb.Load("https://sports.bovada.lv/e-sports/other-e-sports/overwatch");

                //return the html body only
                return document.DocumentNode.InnerHtml;
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
            MainClass mainClass = new MainClass();

            HtmlWeb htmlWeb = new HtmlWeb();

            //use our newly defined read function to grab the html
            HtmlAgilityPack.HtmlDocument pageHtml = htmlWeb.Load(mainClass.read());

            //print it all out
            Console.WriteLine(pageHtml);
            string link = pageHtml.DocumentNode.CssSelect(".table-of-content .head-row td.download a.text-pdf").Single().Attributes["href"].Value.ToString();
            Console.ReadLine();
        }
    }
}
