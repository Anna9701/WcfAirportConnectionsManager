using AirportResources;
using AirportResourcesService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel;

namespace WcfAirportManagerLib
{
    public class AirportService : IAirportService
    {
        private IAirConnectionsDatabase airConnectionsDatabase;

        public AirportService()
        {
            string csvPath = ConfigurationManager.AppSettings["CsvDatabasePath"];
            airConnectionsDatabase = new AirConnectionsDatabase(csvPath);
        }

        public IList<AirConnection> GetAirConnections(string portA, string portB)
        {
            CheckValidityOfAirports(portA, portB);
            IList <AirConnection> list = new List<AirConnection>();
            foreach (AirConnection conn in airConnectionsDatabase.GetAirConnections(portA, portB))
            {
                list.Add(conn);
            }
            if (list.Count == 0)
            {
                throw new FaultException<NoConnectionsFault>(new NoConnectionsFault(), new FaultReason("There is no any connection between those Airports!"));
            }
            return list;
        }

        private bool CheckValidityOfAirports(string portA, string portB)
        {
            string errorMsg = "";
            if (!airConnectionsDatabase.ContainsAirport(portA))
                errorMsg += portA + " ";
            if (!airConnectionsDatabase.ContainsAirport(portB))
                errorMsg += portB + " ";
            if (errorMsg.Length > 0)
            {
                throw new FaultException<InvalidAirportFault>(new InvalidAirportFault(), new FaultReason(String.Format("There is no such airport(s): {0}", errorMsg)));
            }
            return true;
        }

        public IList<AirConnection> GetAirConnections(string portA, string portB, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

    }
}
