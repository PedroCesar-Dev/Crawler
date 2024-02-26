using HtmlAgilityPack;
using System.Reflection.Metadata;

class Program
{
    static async Task Main()
    {
        string mercadolivreSite = "https://lista.mercadolivre.com.br/notebooks#D[A:notebook]";
        string magazineLuizaSite = "https://www.magazineluiza.com.br/busca/notebooks/";

        string nomeProdutoMercadolivre = "";
        string nomeProdutomagazineLuiza = "";

        string precoProdutoMercadolivre = "";
        string precoProdutoMagazineLuiza = "";


        using (HttpClient client = new HttpClient()) 
        {
            HttpResponseMessage response = await client.GetAsync(mercadolivreSite);
            if (response.IsSuccessStatusCode) 
            {
                string html = await response.Content.ReadAsStringAsync();

                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(html);

                HtmlNode nomeNodeMercado = document.DocumentNode.SelectSingleNode("//*[@id=\":Rh59bb:\"]/div[2]/div/div[2]/a/h2");
                nomeProdutoMercadolivre = nomeNodeMercado.InnerText.Trim();

                HtmlNode precoNodeMercado = document.DocumentNode.SelectSingleNode("//*[@id=\":Rh59bb:\"]/div[2]/div/div[3]/div/div/div/span[1]/span[2]");
                precoProdutoMercadolivre = precoNodeMercado.InnerText.Trim();                
            }
            else
            {
                Console.WriteLine("");
            }
            Console.WriteLine(nomeProdutoMercadolivre);
            Console.WriteLine(precoProdutoMercadolivre);
        }
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(magazineLuizaSite);
            if (response.IsSuccessStatusCode)
            {
                string html = await response.Content.ReadAsStringAsync();

                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(html);

                HtmlNode nomeNodeMagazine = document.DocumentNode.SelectSingleNode("/html/body/div[1]/div/main/section[4]/div[5]/div/ul/li[1]/a/div[3]/h2");
                nomeProdutomagazineLuiza = nomeNodeMagazine.InnerText.Trim();

                HtmlNode precoNodeMagazine = document.DocumentNode.SelectSingleNode("/html/body/div[1]/div/main/section[4]/div[5]/div/ul/li[1]/a/div[3]/div[2]/div/div/p");
                precoProdutoMagazineLuiza = precoNodeMagazine.InnerText.Trim();
            }
            else
            {
                Console.WriteLine("");
            }
            Console.WriteLine(nomeProdutomagazineLuiza);
            Console.WriteLine(precoProdutoMagazineLuiza);
        }
        
    }
}