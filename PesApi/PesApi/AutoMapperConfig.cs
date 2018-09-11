using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Pes.DTO;
using Pes.Models;

namespace Pes.Bll.Mappings
{
    class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Bet, BetDTO>().ReverseMap();
            CreateMap<Event, EventDTO>().ReverseMap();
            CreateMap<Game, GameDTO>().ReverseMap();
            CreateMap<Opponent, OpponentDTO>().ReverseMap();
        }
    }
}
