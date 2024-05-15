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

            CreateMap<QuestionDto, Question>();
            CreateMap<Question, QuestionDto>();

            //CreateMap<InternshipProgram, InternshipProgramDto>()
            //    .ForMember(dest => dest.Id, opt => opt.Ignore()); 
            //CreateMap<InternshipProgramDto, InternshipProgram>(); 

            CreateMap<InternshipProgram, InternshipProgramDto>();
               
            CreateMap<InternshipProgramDto, InternshipProgram>();


            //works
            CreateMap<CreateProgramDto, InternshipProgram>();
               
            CreateMap<InternshipProgram, CreateProgramDto>();


           
            CreateMap<Answer, Answer>();
            CreateMap<AnswerDto, Answer>();
            CreateMap<Answer, AnswerDto>();

            CreateMap<CreateApplicationDto, Applications>();           
            CreateMap<Applications, CreateApplicationDto>();

            CreateMap<Applications, ApplicationDto>();            
            CreateMap<ApplicationDto, Applications>();



        }
    }
}
