namespace GenericDemo.Domain.Mapping
{
    using AutoMapper;

    using GenericDemo.Domain.Models;
    using GenericDemo.Dto;
    using GenericDemo.Dto.Requests;

    public class LikeMapping : Profile
    {
        public LikeMapping()
        {
            CreateMap<Like, LikeDto>()
                .ForMember(dest => dest.Id, action => action.MapFrom(src => src.Id))
                .ForMember(dest => dest.LanguageId, action => action.MapFrom(src => src.LanguageId))
                .ForMember(dest => dest.Name, action => action.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, action => action.MapFrom(src => src.Email))
                .ForAllOtherMembers(dest => dest.Ignore());

            CreateMap<CreateLikeDto, Like>()
                .ForMember(dest => dest.LanguageId, action => action.MapFrom(src => src.LanguageId))
                .ForMember(dest => dest.Name, action => action.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, action => action.MapFrom(src => src.Email))
                .ForAllOtherMembers(dest => dest.Ignore());

            CreateMap<UpdateLikeDto, Like>()
                .ForMember(dest => dest.LanguageId, action => action.MapFrom(src => src.LanguageId))
                .ForMember(dest => dest.Name, action => action.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, action => action.MapFrom(src => src.Email))
                .ForAllOtherMembers(dest => dest.Ignore());
        }
        
    }
}
