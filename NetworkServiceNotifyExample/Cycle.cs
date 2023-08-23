using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkServiceNotifyExample
{
    public class Cycle
    {
        public bool InCycle { get; set; }
        public DateTime? CycleStart { get; set; }
        public DateTime? TimeOfMaxValue { get; set; }
        public double? MaxValue { get; set; }
        public List<double> CurrentDataList { get; set; }

        public Cycle()
        {
            InCycle = false;
            CycleStart = null;
            TimeOfMaxValue = null;
            MaxValue = 0;
            CurrentDataList = new List<double>();
        }
    }

    public class CycleManager
    {
        public void StartCycle(Cycle cycle, double result)
        {

        }
    }
}
