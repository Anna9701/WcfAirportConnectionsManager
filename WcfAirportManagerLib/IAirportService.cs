using AirportResources;
using AirportResourcesService;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfAirportManagerLib
{
    [ServiceContract]
    public interface IAirportService
    {
        [OperationContract(Name = "GetAllAirConnections")]
        IList<AirConnection> GetAirConnections(string portA, string portB);

        [OperationContract(Name = "GetAirConnections")]
        IList<AirConnection> GetAirConnections(string portA, string portB, DateTime from, DateTime to);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfAirportManagerLib.ContractType".
    [DataContract]
    public class AirConnetions 
    {
        private IList<AirConnection> airConnections;

        public AirConnetions(IList<AirConnection> connections) => airConnections = connections;

        [DataMember]
        public IList<AirConnection> AirConnections
        {
            get => airConnections;
        }
    }
}