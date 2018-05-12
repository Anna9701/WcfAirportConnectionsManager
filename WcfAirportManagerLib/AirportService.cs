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
            IList<AirConnection> list = new List<AirConnection>();
            foreach (AirConnection conn in airConnectionsDatabase.GetAirConnections(portA, portB))
            {
                list.Add(conn);
            }
            if (list.Count == 0)
            {
                NoConnectionsFault fault = new NoConnectionsFault
                {
                    Description = "No any connection available",
                    Message = "There is no any connection between those Airports!",
                    Result = false
                };
                throw new FaultException<NoConnectionsFault>(fault, new FaultReason(fault.Message));
            }
            return list;
        }

        public IList<AirConnection> GetAirConnections(string portA, string portB, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

    }
}
