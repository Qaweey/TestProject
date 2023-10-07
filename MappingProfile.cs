using AutoMapper;
using CapitalPlacement.Dtos;
using CapitalPlacement.Models;
using Profile = AutoMapper.Profile;

namespace CapitalPlacement
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddAQuestion, AddAQuestionDto>().ReverseMap();
            CreateMap<MultipleChoiceQuestions, MultipleChoiceQuestionsDto>().ReverseMap();
            CreateMap<DropDown, DropDownDto>().ReverseMap();
            CreateMap<Profile, ProfileDto>().ReverseMap();
            CreateMap<Education, EducationDto>().ReverseMap();
            CreateMap<WorkExperience, WorkExperienceDto>().ReverseMap();
            CreateMap<AdditionalQuestions, AdditionalQuestionsDto>().ReverseMap();
            CreateMap<ProgramDetails, ProgramDetailsDto>().ReverseMap();
            CreateMap<AdditionalProgramInfo, AdditionalProgramInfoDto>().ReverseMap();
            CreateMap<WorkFlow, WorkFlowDto>().ReverseMap();
            CreateMap<WorkFlow, WorkFlowDto>().ReverseMap();



            // Add other mappings as needed
        }
    }
}
