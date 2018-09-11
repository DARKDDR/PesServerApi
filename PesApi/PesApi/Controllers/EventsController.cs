using Pes.DTO;
using Pes.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PesServerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService ies;

        public EventsController(IEventService es)
        {
            ies = es;
        }
        // GET api/values
        [HttpGet]
        public ICollection<EventDTO> Get(GameDTO game)
        {
            List<EventDTO> events = new List<EventDTO>();
            events = ies.GetByGame(game).ToList();
            return events;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public EventDTO Get(int id)
        {
            EventDTO @event = ies.GetById(id);
            return @event;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] EventDTO @event)
        {
            ies.Create(@event);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EventDTO value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            EventDTO @event = ies.GetById(id);
            //Pas de méthode delete pour le moment
        }
    }
}