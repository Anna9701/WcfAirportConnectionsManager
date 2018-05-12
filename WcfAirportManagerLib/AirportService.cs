using AirportResources;
using AirportResourcesService;
using System;
using System.Collections.Generic;
using System.Configuration;

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
            IList<AirConnection> list = new List<AirConnection>();
            foreach (AirConnection conn in airConnectionsDatabase.GetAirConnections(portA, portB))
            {
                list.Add(conn);
            }
            return list;
        }

        public IList<AirConnection> GetAirConnections(string portA, string portB, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

    }
}
