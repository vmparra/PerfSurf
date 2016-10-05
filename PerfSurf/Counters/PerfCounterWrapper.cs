using System.Diagnostics;

namespace PerfSurf.Counters
{
    public class PerfCounterWrapper
    {
        private readonly PerformanceCounter _counter;

        public PerfCounterWrapper(string name, string category, string counter, string instance = "")
        {
            _counter = new PerformanceCounter(category, counter, instance, true);
            Name = name;
        }

        public string Name { get; set; }
        public float Value => _counter.NextValue();
    }
}