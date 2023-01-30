using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly S18351Context _context;
        public TripsController(S18351Context context)
        {
            _context = context;
        }

        // GET: api/<TripsController>
        [HttpGet]
        public IActionResult GetTrips()
        {
            var trips = _context.Trips.OrderByDescending(a => a.DateFrom)
                .Include(x => x.ClientTrips);
            return Ok(trips.Select(x=> new TripInfoDTO(x)));
        }

        // GET api/<TripsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TripsController>
        [HttpPost]
        public IActionResult Post([FromBody] Trip trip)
        {
            _context.Trips.Add(trip);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("{id}/clients")]
        public IActionResult AddClientToTrip(int id, [FromBody] AddClientToTripDTO addClientDTO)
        {
            Trip? t = _context.Trips.SingleOrDefault(x => x.IdTrip == id);

            if(t == null)
            {
                return BadRequest("No such trip");
            }

            Client? c = _context.Clients.SingleOrDefault(x => x.Pesel == addClientDTO.Pesel);

            if(c != null) {
                if(t.ClientTrips.Any(x => x.IdClient == c.IdClient))
                {
                    return BadRequest("Client already registered");
                }
            }
            else
            {
                _context.Clients.Add(addClientDTO);
                _context.SaveChanges();
                
                c = addClientDTO;
            }

            t.ClientTrips.Add(new ClientTrip
            {
                IdClientNavigation = c,
                IdTripNavigation= t,
                PaymentDate = addClientDTO.PaymentDate,
                RegisteredAt = DateTime.Now,
            });

            _context.SaveChanges();

            return Ok();
        }
    }
}
