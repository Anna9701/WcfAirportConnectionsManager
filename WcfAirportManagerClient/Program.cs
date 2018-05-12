using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfAirportManagerClient
{
    class Program
    {
        static void Main(string[] args)
        {
            AirportServiceClient client = new AirportServiceClient();
            var conns = client.GetAllAirConnections("Warsaw", "Berlin");
            // Use the 'client' variable to call operations on the service.
            // Always close the client.
            client.Close();
            System.Console.ReadKey();
        }
    }
}
