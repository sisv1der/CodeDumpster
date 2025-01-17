using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson0._Classes__console_output
{
    internal class Tank(int id, string name, string description, double volume, double maxVolume, int unitId)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public double Volume { get; set; } = volume;
        public double MaxVolume { get; set; } = maxVolume;
        public int UnitId { get; set; } = unitId;
    }
}
