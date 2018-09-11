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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService us)
        {
            this._userService = us;
        }

        // GET: api/Games
        [HttpGet]
        public IEnumerable<UserDTO> Get(BetDTO bet)
        {
            return _userService.GetByBet(bet);
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public UserDTO Get(int id)
        {
            return _userService.GetUserById(id);
        }

        // POST: api/Games
        [HttpPost]
        public void Post([FromBody] UserDTO user)
        {
            _userService.Create(user);
        }
    }
}