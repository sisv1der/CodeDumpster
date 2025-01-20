using System.Text.Json;
using static Lesson_1._Part_1._JSON_Parsing_and_Using_LINQ.Deal;
namespace Lesson_1._Part_1._JSON_Parsing_and_Using_LINQ
{
    internal class Program
    {
        public static IList<SumByMonth> GetSumsByMonth(IEnumerable<Deal> deals)
        {
            return deals
                .GroupBy(deal => new DateTime(deal.Date.Year, deal.Date.Month, deal.Date.Day))
                .Select(group => new SumByMonth(
                    Month: group.Key,
                    Sum: group.Sum(deal => deal.Sum)
                    ))
                .OrderBy(result => result.Month)
                .ToList();
        }
        public static IList<string> GetNumbersOfDeals(IEnumerable<Deal> deals)
        {
            return deals
                .Where(deal => deal.Sum >= 100)
                .OrderBy(deal => deal.Date)
                .Take(5)
                .OrderByDescending(deal => deal.Sum)
                .Select(deal => deal.Id)
                .ToList();
        }
        static void Main(string[] args)
        {
            var json = File.ReadAllText("json/JSON_sample_1.json");
            var deals = JsonSerializer.Deserialize<IList<Deal>>(json);

            var dealsId = GetNumbersOfDeals(deals);
            foreach (string dealId in dealsId)
            {
                Console.Write(dealId + " ");
            }
            Console.WriteLine();
            var sumsByMonth = GetSumsByMonth(deals);
            for(int i = 0; i < sumsByMonth.Count; i++)
            {
                Console.WriteLine("YEAR: " + sumsByMonth[i].Month.Year + "; \tMONTH: " + sumsByMonth[i].Month.Month + ";\t SUM: " + sumsByMonth[i].Sum);
            }


            // выводит одинаковые ID, потому что автор json файла (а он не мой) написал там так эти ID

        }
    }
}
