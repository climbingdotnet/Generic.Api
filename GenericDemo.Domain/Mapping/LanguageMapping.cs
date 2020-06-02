namespace GenericDemo.Domain.Mapping
{
    using AutoMapper;

    using GenericDemo.Domain.Models;
    using GenericDemo.Dto;
    using GenericDemo.Dto.Requests;

    public class LanguageMapping : Profile
    {
        public LanguageMapping()
        {
            CreateMap<Language, LanguageDto>()
                .ForMember(dest => dest.Id, action => action.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, action => action.MapFrom(src => src.Name))
                .ForAllOtherMembers(dest => dest.Ignore());

            CreateMap<CreateLanguageDto, Language>()
                .ForMember(dest => dest.Name, action => action.MapFrom(src => src.Name))
                .ForAllOtherMembers(dest => dest.Ignore());

            CreateMap<UpdateLanguageDto, Language>()
                .ForMember(dest => dest.Name, action => action.MapFrom(src => src.Name))
                .ForAllOtherMembers(dest => dest.Ignore());
        }
    }
}
