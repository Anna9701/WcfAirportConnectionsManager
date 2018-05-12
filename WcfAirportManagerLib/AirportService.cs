using AirportResources;
using AirportResourcesService;
using System;
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

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
