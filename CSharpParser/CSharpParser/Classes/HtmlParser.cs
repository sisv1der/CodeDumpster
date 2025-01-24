using System;
using System.Collections.Generic;
using System.Data;
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
        
        public async Task<List<ProductInfo>> ParserNKatalog(string pageUrl)
        {
            // загрузка html page
            var html = await _httpClient.GetStringAsync(pageUrl);
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            
            // воруем строчки <tr> с нужным рейтингом-атрибутом rp
            var rowsWithRp = htmlDoc.DocumentNode.SelectNodes(@"//tr[@rp]");
            if (rowsWithRp == null)
            {
                return new List<ProductInfo>(); // пустой список если таких строчек нет, можно и нулл, в целом
                // return null
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
                    var nameNode = row.SelectSingleNode(".//noindex/p[@class='where-buy-title']");
                    if (nameNode != null) // тест на аутизм 
                    {
                        productInfo.ProductName = WebUtility.HtmlDecode(nameNode.InnerText).Trim();
                    }

                    // хватаем нодик с урл на селлера
                    var sellerNode = row.SelectSingleNode(".//div[@id='where-buy-title-name']/text()");
                    if (sellerNode != null)
                    {
                        productInfo.SellerUrl = WebUtility.HtmlDecode(sellerNode.InnerText).Trim();
                    }

                    // хватаем нодик с ценой в рублс
                    var priceNode = row.SelectSingleNode(".//td[@class='where-buy-price']/a[@class='where-buy-price__link']");
                    if (priceNode != null)
                    {
                        productInfo.Price = WebUtility.HtmlDecode(priceNode.InnerText).Trim();
                    }

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
