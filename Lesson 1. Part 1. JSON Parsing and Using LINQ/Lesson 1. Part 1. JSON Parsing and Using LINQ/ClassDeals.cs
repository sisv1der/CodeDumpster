using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1._Part_1._JSON_Parsing_and_Using_LINQ
{
    internal class Deal(int sum, string id, DateTime date)
    {
        public int Sum { get; set; } = sum;
        public string Id { get; set; } = id;
        public DateTime Date { get; set; } = date;
        public record SumByMonth(DateTime Month, int Sum);

        // Реализовать метод GetSumsByMonth,
        // который принимает коллекцию объектов класса Deal,
        // группирует по месяцу сделки и возвращает сумму сделок за каждый месяц
    }
}
