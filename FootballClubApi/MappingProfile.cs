using AutoMapper;
using Entities.DTO;
using Entities.Models;

namespace FootballClubApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Club, ClubDto>();
        CreateMap<Player, PlayerDto>();
        CreateMap<ClubForCreationDto, Club>();
        CreateMap<PlayerForCreationDto, Player>();
        CreateMap<ClubAndPlayerForCreationDto, Club>();
        CreateMap<PlayerForUpdateDto, Player>();
        CreateMap<ClubForUpdateDto, Club>();
    }
}