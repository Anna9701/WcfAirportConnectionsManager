using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfAirportManagerClient
{
    class AirportManager : IDisposable
    {
        private static int QuitInputLenght => 1;
        private static int AmountParametersForAllConnections => 2;
        private static int AmountParametersForConnectionInTimeRange => 4;
        private ServiceClient serviceClient;

        public AirportManager() => serviceClient = new ServiceClient();

        public void HandleClientInputsInLoop()
        {
            do {
                try {
                    DisplayPrompt();
                } catch (InvalidInputException ex) {
                    Console.Error.WriteLine(String.Format("ERROR: {0}. Please, provide valid arguemnts.", ex.Message));
                }
            } while (GetInput());
            Console.Out.WriteLine("Bye");
        }

        private bool GetInput()
        {
            var input = Console.ReadLine();
            if (input.Length == QuitInputLenght && Char.ToUpper(input[0]).Equals('Q')) return false;
            HandleInput(input);
            return true;
        }

        private void HandleInput(string input)
        {
            IList<string> dividedInput = input.Split(' ');
            if (dividedInput.Count == AmountParametersForAllConnections)
            {
                var connections = serviceClient.GetAllAirConnections(dividedInput[0], dividedInput[1]);
                PrintConnections(connections);
            }
            else if (dividedInput.Count == AmountParametersForConnectionInTimeRange)
            {

            }
            else throw new InvalidInputException("Provided number of arguments is wrong.");
        }

        public void PrintConnections(IList<AirportResources.AirConnection> connections)
        {
            foreach (var conn in connections)
            {
                Console.Out.WriteLine(String.Format("From: {0}\t To: {1}\t Departure: {2}\t Arrival: {3}", conn.AirportA, conn.AirportB, conn.DepartureTime, conn.ArrivalTime));
            }
        }

        private void DisplayPrompt()
        {
            Console.WriteLine("Enter <Departure Airport> <Destination Airport> and optionally <Departure time> <Arrival time>. If you want to quit, enter Q.");
        }

        public void Dispose()
        {
            serviceClient.Dispose();
        }
    }

}
