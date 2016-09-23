using System;
using System.Collections.Generic;

namespace designPatterns.Domain.DesignPattern.BuilderPattern
{
    public class Vehicle
    {
        private readonly string _vehicleType;

        private readonly Dictionary<string, string> _parts =
            new Dictionary<string, string>();

        public Vehicle(string vehicleType)
        {
            this._vehicleType = vehicleType;
        }

        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }

        public List<string> Show()
        {
            var returnList = new List<string>
            {
                string.Format("Vehicle Type: {0}", _vehicleType),
                string.Format(" Frame : {0}", _parts["frame"]),
                string.Format(" Engine : {0}", _parts["engine"]),
                string.Format(" #Wheels: {0}", _parts["wheels"]),
                string.Format(" #Doors : {0}", _parts["doors"])
            };
            return returnList;
        }
    }
}