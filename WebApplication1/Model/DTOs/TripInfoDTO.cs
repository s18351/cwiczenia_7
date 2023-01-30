namespace WebApplication1.Model.DTOs
{
    public class TripInfoDTO
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public int MaxPeople { get; set; }
        public List<Country> Countries { get; set; }
        public List<ClientDTO> Clients { get; set; }

        public TripInfoDTO(Trip t)
        {
            Name = t.Name;
            DateFrom = t.DateFrom;
            DateTo = t.DateTo;
            Description = t.Description;
            MaxPeople = t.MaxPeople;
            Clients = t.ClientTrips.Select(x => new ClientDTO {
                FirstName = x.IdClientNavigation.FirstName,
                LastName = x.IdClientNavigation.LastName
            }).ToList();
            Countries = t.IdCountries.ToList();
        }
    }
}
