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
    public class GamesController : ControllerBase
    {
        private readonly IGameService igs;

        public GamesController(IGameService gs)
        {
            this.igs = gs;
        }

        // GET: api/Games
        [HttpGet]
        public IEnumerable<GameDTO> Get()
        {
            return igs.GetListGameDTO();
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public GameDTO Get(int id)
        {
            return igs.GetById(id);
        }

    
    }
}