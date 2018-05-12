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
            try {
                var conns = client.GetAllAirConnections("Warsaw2", "Berlin");
            } catch (TimeoutException timeProblem) {
                Console.Error.WriteLine(String.Format("The service operation timed out. {0}", timeProblem.Message));
                client.Abort();
            } catch (FaultException<WcfAirportManagerLib.NoConnectionsFault> ex) {
                Console.Error.WriteLine(ex.Message);
            } catch (FaultException<WcfAirportManagerLib.InvalidInputFault> ex) {
                Console.Error.WriteLine(ex.Message);
            } catch (FaultException<WcfAirportManagerLib.InvalidAirportFault> ex) {
                Console.Error.WriteLine(ex.Message);
            } catch (CommunicationException commProblem) {
                Console.Error.WriteLine(String.Format("There was a communication problem. {0}", commProblem.Message));
                client.Abort();
            }

            client.Close();
            System.Console.ReadKey();
        }
    }
}
