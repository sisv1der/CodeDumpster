using CSharpParser.Classes;
using System.Net.WebSockets;

namespace CSharpParser
{
    internal class Program
    {
        static string Input(string msg)
        {
            Console.Write(msg);
            return Console.ReadLine();
        }
        static async Task<List<ProductInfo>> GetProductInfo(string url)
        {
            var htmlParser = new HtmlParser();
            var task = htmlParser.ParserNKatalog(url);
            List<ProductInfo> productInfos = await task;
            return productInfos;
        }
        static async Task Main(string[] args)
        {
            var url = Input("Введите URL: ");
            Console.WriteLine();
            List<ProductInfo> productInfos = await GetProductInfo(url);
            foreach (var productInfo in productInfos)
            {
                Console.WriteLine();
                Console.WriteLine($"Товар: {productInfo.ProductName}; Продавец: {productInfo.SellerUrl}; Цена: {productInfo.Price}");
                Console.WriteLine();
                Console.WriteLine(new string('=', 125));
            }
        }
    }
}
