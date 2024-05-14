using AutoMapper;
using dotnet_task.Domain.Models;
using dotnet_task.DTO;

namespace dotnet_task.Mappings
{
  
    public class ProgramProfile : Profile
    {
        public ProgramProfile()
        {
           

            CreateMap<Question, Question>();

            //CreateMap<InternshipProgram, InternshipProgramDto>()
            //    .ForMember(dest => dest.Id, opt => opt.Ignore()); 
            //CreateMap<InternshipProgramDto, InternshipProgram>(); 


            ////works
            //CreateMap<CreateProgramDto, InternshipProgram>()
            //   .ForMember(dest => dest.Id, opt => opt.Ignore()); 
            //CreateMap<InternshipProgram, CreateProgramDto>();


            CreateMap<InternshipProgram, InternshipProgramDto>();
               
            CreateMap<InternshipProgramDto, InternshipProgram>();


            //works
            CreateMap<CreateProgramDto, InternshipProgram>();
               
            CreateMap<InternshipProgram, CreateProgramDto>();


            //CreateMap<CreateProgramDto, InternshipProgramDto>().ReverseMap();
            CreateMap<Answer, Answer>(); // Mapping for Question class

            //CreateMap<CreateApplicationDto, ApplicationDto>()
            //    .ForMember(dest => dest.Id, opt => opt.Ignore()); 
            //CreateMap<ApplicationDto, CreateApplicationDto>(); 

            //CreateMap<Applications, ApplicationDto>()
            //   .ForMember(dest => dest.Id, opt => opt.Ignore());
            //CreateMap<ApplicationDto, Applications>();


            CreateMap<CreateApplicationDto, Applications>();           
            CreateMap<Applications, CreateApplicationDto>();

            CreateMap<Applications, ApplicationDto>();            
            CreateMap<ApplicationDto, Applications>();



        }
    }
}
