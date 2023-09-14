using WebParserCli.Gismeteo;
using WebParserCli.OpenWeatherMap;
using WebParserCli.Tutu;

namespace WebParserCli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //new TutuHtmlParser().Go();
            new OpenWeatherMapClient().Go();
        }
    }
}