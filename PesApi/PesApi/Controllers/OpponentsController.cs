using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pes.DTO;
using Pes.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PesServerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpponentsController : ControllerBase
    {
        private readonly IOpponentService ios;

        public OpponentsController(IOpponentService os)
        {
            this.ios = os;
        }

        // GET: api/Games
        [HttpGet]
        public IEnumerable<OpponentDTO> Get(EventDTO eventDTO)
        {
            return ios.GetByEvent(eventDTO);
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public OpponentDTO Get(int id)
        {
            return ios.GetById(id);
        }

       
    }
}