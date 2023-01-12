using System;
using System.Collections.Generic;
using System.Globalization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static SpaceTraders.AvailableShips.ShipListing;

namespace SpaceTraders.AvailableShips
{
  public partial class AvailableShipsDTO
  {
    [JsonProperty("shipListings")]
    public ShipListing[] ShipListings { get; set; }

  }

  public partial class ShipListing
  {
    [JsonProperty("type")]
    public string Type { get; set; }

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

    [JsonProperty("purchaseLocations")]
    public PurchaseLocation[] PurchaseLocations { get; set; }

  }
    public partial class PurchaseLocation
    {
      [JsonProperty("system")]
      public string System { get; set; }

      [JsonProperty("location")]
      public string Location { get; set; }

      [JsonProperty("price")]
      public int Price { get; set; }
    }
  }
