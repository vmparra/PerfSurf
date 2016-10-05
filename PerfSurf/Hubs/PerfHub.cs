using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using PerfSurf.Counters;

namespace PerfSurf.Hubs
{
    public class PerfHub : Hub
    {
        public PerfHub()
        {
            StartCounterCollection();
        }

        private void StartCounterCollection()
        {
            Task.Factory.StartNew(async () =>
            {
                var service = new PerfCounterService();
                while (true)
                {
                    var results = service.GetResults();
                    Clients.All.newCounters(results);
                    await Task.Delay(2000);
                }

            }, TaskCreationOptions.LongRunning);
        }

        public void Send(string message)
        {
            Clients.All.newMessage(
                Context.User.Identity.Name + " says " + message
                );
        }
    }
}