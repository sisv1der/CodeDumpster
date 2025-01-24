using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace CSharpParser.Classes
{
    internal class HtmlParser
    {
        private static readonly HttpClient _httpClient = new();

        private static string GetHtmlNode(HtmlNode row, string XPath)
        {
            var node = row.SelectSingleNode(XPath);
            return WebUtility.HtmlDecode(node.InnerText).Trim();
        }

        private static HtmlNodeCollection GetRows(HtmlDocument htmlDocument,string XPath)
        {
            var rows = htmlDocument.DocumentNode.SelectNodes(XPath);
            return rows;
        }
        private static async Task<HtmlDocument> GetHtmlPage(string pageUrl)
        {
            var html = await _httpClient.GetStringAsync(pageUrl);
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            return htmlDoc;
        } 
        public async Task<List<ProductInfo>> ParserNKatalog(string pageUrl)
        {
            // загрузка html page
            var htmlDocument = await GetHtmlPage(pageUrl);

            // воруем строчки <tr> с нужным рейтингом-атрибутом rp
            var rowsWithRp = GetRows(htmlDocument, "//tr[@rp]");
            if (rowsWithRp == null)
            {
                return new List<ProductInfo>();
            }
            
            // листик товаров
            var products = new List<ProductInfo>();

            try
            {
                foreach (var row in rowsWithRp) // перебор строчек <tr> с атрибутом rp
                {
                    // наш продуктик
                    var productInfo = new ProductInfo();
                    // хватаем нодик с именем
                    productInfo.ProductName = GetHtmlNode(row, ".//noindex/p[@class='where-buy-title']");
                    // хватаем нодик с именем

                    // хватаем нодик с урл на селлера
                    productInfo.SellerUrl = GetHtmlNode(row, ".//div[@id='where-buy-title-name']/text()");

                    // хватаем нодик с ценой в рублс
                    productInfo.Price = GetHtmlNode(row, ".//td[@class='where-buy-price']/a[@class='where-buy-price__link']");

                    // если хотяб один стринг ссылается на нулл/равен empty,
                    // то добавляем прикол в список для возврата
                    if (!string.IsNullOrEmpty(productInfo.ProductName) ||
                        !string.IsNullOrEmpty(productInfo.SellerUrl) ||
                        !string.IsNullOrEmpty(productInfo.Price))
                    {
                        products.Add(productInfo);
                    }
                }
                return products;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ProductInfo>();
            }
        }
    }
    internal class ProductInfo
    {
        public string ProductName { get; set; }
        public string SellerUrl { get; set; }
        public string Price { get; set; }
    }
}
