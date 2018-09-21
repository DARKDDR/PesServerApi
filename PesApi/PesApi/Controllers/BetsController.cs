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
    public class BetsController : ControllerBase
    {
        private readonly IBetService ibs;

        public BetsController(IBetService bs)
        {
            ibs = bs;
        }
        // GET api/values
        [HttpGet]
        public ICollection<BetDTO> Get(UserDTO user)
        {
            List<BetDTO> bets = new List<BetDTO>();
            bets = ibs.GetByUser(user).ToList();
            return bets;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public BetDTO Get(int id)
        {
            BetDTO bet = ibs.GetById(id);
            return bet;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] BetDTO value)
        {
            ibs.Create(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BetDTO value)
        {
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            BetDTO bet = ibs.GetById(id);
            ibs.Delete(bet);
        }
    }
}