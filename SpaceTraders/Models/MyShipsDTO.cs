using Newtonsoft.Json;
using SpaceTraders.LoanedLoans;

namespace SpaceTraders.ShipsOwned
{
    public class MyShipsDTO
    {
            [JsonProperty("ships")]
            public Ships[] Ship { get; set; }
        
    }
    public partial class Ships
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("x")]
        public int X { get; set; }

        [JsonProperty("y")]
        public int Y { get; set; }

        [JsonProperty("cargo")]
        public string[] Cargo { get; set; }

        [JsonProperty("spaceAvailable")]
        public int SpaceAvailable { get; set; }

        [JsonProperty("type")]
        public string Type{ get; set; }

        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("maxCargo")]
        public int MaxCargo { get; set; }

        [JsonProperty("loadingSpeed")]
        public int LoadingSpeed { get; set; }

        [JsonProperty("speed")]
        public int Speed { get; set; }

        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonProperty("plating")]
        public int Plating { get; set; }

        [JsonProperty("weapons")]
        public int Weapons { get; set; }

    }
    }
