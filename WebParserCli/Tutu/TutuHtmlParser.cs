using HtmlAgilityPack;

namespace WebParserCli.Tutu
{
    internal class TutuHtmlParser
    {
        public void Go()
        {
            //var document = GetDocumentFromSavedPage();
            var document = GetDocumentFromWeb();
            var schedule = GetSchedule(document);
            PrintNodes(schedule);
        }

        private HtmlDocument GetDocumentFromWeb()
        {
            string url = "https://www.tutu.ru/aeroexpress/schedule/";
            HttpClient _client = new HttpClient();

            using (var response = _client.GetAsync(url).Result)
            using (var stream = response.Content.ReadAsStreamAsync().Result)
            {
                var document = new HtmlDocument();
                document.Load(stream);
                return document;
            }
        }

        private HtmlDocument GetDocumentFromSavedPage()
        {
            string filePath = @"Tutu\Расписание Аэроэкспресса - Шереметьево.html";
            var document = new HtmlDocument();
            document.Load(filePath);
            return document;
        }

        private HtmlNodeCollection GetSchedule(HtmlDocument document)
        {
            var nodes = document.DocumentNode.SelectNodes("//body/div/div/div/div/table/tr/td[@class='tooltip']");
            //var nodes = document.DocumentNode.SelectNodes("//td[@class='tooltip']");

            return nodes;
        }


        private static void PrintNodes(HtmlNodeCollection nodes)
        {
            foreach (var node in nodes)
            {
                Console.WriteLine(node.InnerText);
            }
        }
    }
}
