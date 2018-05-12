using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfAirportManagerClient
{
    class Program
    {
        static void Main(string[] args)
        {
            AirportServiceClient client = new AirportServiceClient();
            try
            {
                var conns = client.GetAllAirConnections("Warsaw2", "Berlin");
            } catch (FaultException<WcfAirportManagerLib.NoConnectionsFault> ex)
            {
                Console.Error.WriteLine(ex.Message);
            } catch (FaultException<WcfAirportManagerLib.InvalidInputFault> ex)
            {
                Console.Error.WriteLine(ex.Message);
            } catch (FaultException<WcfAirportManagerLib.InvalidAirportFault> ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
             
            client.Close();
            System.Console.ReadKey();
        }
    }
}
