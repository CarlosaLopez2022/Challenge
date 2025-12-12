using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Data
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Forecast
    {
        public string day { get; set; }
        public string temperature { get; set; }
        public string wind { get; set; }
    }

    public class Root
    {
        public string temperature { get; set; }
        public string wind { get; set; }
        public string description { get; set; }
        public List<Forecast> forecast { get; set; }
    }
    public class City
    {
        public string Name { get; set; }
        public Root Root { get; set; }
        public string LastUpdated { get; set; }
        public City(string name)
        {
            Name = name;
            Root = new Root();
            Root.temperature = string.Empty;
            Root.description = string.Empty;
        }
    }
}
