using AutoMapper;
using netCoreCourse.Models;
using netCoreCourse.Dtos;

namespace netCoreCourse.Profiles
{

    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandReadDto>();

            CreateMap<CommandCreateDto, Command>();

            CreateMap<CommandUpdateDto, Command>();
            
            CreateMap<Command, CommandUpdateDto>();
          //  CreateMap<CommandCreateDto, CommandReadDto>();

          //  CreateMap<CommandReadDto, CommandCreateDto>();
        }
    }
}