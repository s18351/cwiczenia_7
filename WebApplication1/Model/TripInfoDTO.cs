namespace WebApplication1.Model
{
    public class TripInfoDTO : Trip
    {
        public List<Country> Countries { get; set; }
        public List<Client> Clients { get; set; }

        public TripInfoDTO(Trip t)
        {
            this.DateFrom = t.DateFrom;
            this.DateTo = t.DateTo;
            this.Description  = t.Description;
            this.MaxPeople  = t.MaxPeople;
            Clients = t.ClientTrips.Select(x => x.IdClientNavigation).ToList();
            Countries = t.IdCountries.ToList();
        }
    }
}
