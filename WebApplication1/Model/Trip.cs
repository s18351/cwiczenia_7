using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApplication1.Model;

public partial class Trip
{
    public int IdTrip { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }

    public int MaxPeople { get; set; }

    [JsonIgnore]
    public virtual ICollection<ClientTrip> ClientTrips { get; } = new List<ClientTrip>();

    [JsonIgnore]
    public virtual ICollection<Country> IdCountries { get; } = new List<Country>();
}
