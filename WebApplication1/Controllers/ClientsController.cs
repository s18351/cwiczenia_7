using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly S18351Context _context;
        public ClientsController(S18351Context context)
        {
            _context = context;
        }

        // DELETE api/<ClientsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var client = _context.Clients.FirstOrDefault(x => x.IdClient == id);

            if (client == null)
            {
                return BadRequest("No such client");
            }

            _context.Clients.Remove(client);
            _context.SaveChanges();
            return Ok();
        }
    }
}
