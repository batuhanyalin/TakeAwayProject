using AutoMapper;
using TakeAway.Comment.Dtos;
using TakeAway.Comment.Entities;

namespace TakeAway.Comment.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<UserComment,ResultUserCommentDto>().ReverseMap();
            CreateMap<UserComment,UpdateUserCommentDto>().ReverseMap();
            CreateMap<UserComment,GetByIdUserCommentDto>().ReverseMap();
            CreateMap<UserComment,GetByProductIdUserCommandDto>().ReverseMap();
            CreateMap<UserComment,CreateUserCommentDto>().ReverseMap();
        }
    }
}
