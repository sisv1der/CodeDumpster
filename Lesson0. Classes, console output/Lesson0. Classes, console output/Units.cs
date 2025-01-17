using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson0._Classes__console_output
{
    internal class Unit(int id, string name, string description, int factoryId)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public int FactoryId { get; set; } = factoryId;
    }
}
