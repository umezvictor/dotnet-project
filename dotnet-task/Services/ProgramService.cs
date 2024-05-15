using AutoMapper;
using dotnet_task.Constants;
using dotnet_task.Domain.Models;
using dotnet_task.DTO;
using dotnet_task.Repository;
using dotnet_task.Responses;

namespace dotnet_task.Services
{
    public class ProgramService : IProgramService
    {
        private readonly IProgramRepository _programRepository;
        private readonly IMapper _mapper;

        public ProgramService(IProgramRepository programRepository, IMapper mapper)
        {
            _programRepository = programRepository;
            _mapper = mapper;
        }


       
        public async Task<Response<InternshipProgramDto>> CreateProgram(CreateProgramDto programDto)
        {
            //check if the question types are valid
            foreach(var keyValuePair in programDto.PersonalInformation)
            {
                if(!QuestionTypeConstants.QuestionTypes.Contains(keyValuePair.Key))
                    return new Response<InternshipProgramDto>("Invalid question type", false);
            }

            foreach (var keyValuePair in programDto.AdditionalQuestions)
            {
                if (!QuestionTypeConstants.QuestionTypes.Contains(keyValuePair.Key))
                    return new Response<InternshipProgramDto>("Invalid question type", false);
            }
            var program = _mapper.Map<InternshipProgram>(programDto);
            var response = await _programRepository.CreateProgramAsync(program);
            if (response != null)
                return new Response<InternshipProgramDto>(_mapper.Map<InternshipProgramDto>(response));
            return new Response<InternshipProgramDto>("Program was not created.", false);
        }

        
        public async Task<Response<List<InternshipProgramDto>>> GetPrograms()
        {

            var response = await _programRepository.GetProgramsAsync();
            var programs = response.ToList();
            if (programs != null)
                return new Response<List<InternshipProgramDto>>(_mapper.Map<List<InternshipProgramDto>>(programs));
            return new Response<List<InternshipProgramDto>>("No records found");
        }

       
        public async Task<Response<InternshipProgramDto>> GetProgram(string id)
        {

            var program = await _programRepository.GetProgramAsync(id);
            if (program != null)
                return new Response<InternshipProgramDto>(_mapper.Map<InternshipProgramDto>(program));
            return new Response<InternshipProgramDto>("No record found");
        }


        
        public async Task<Response<string>> UpdateProgram(EditQuestionDto editQuestionDto)
        {
            bool isUpdated = false;
            var program = await _programRepository.GetProgramAsync(editQuestionDto.ProgramId);
            if (program != null)
            {

                var additionalQuestions = program.AdditionalQuestions;
                // Check if the question type exists in the dictionary
                if (additionalQuestions.ContainsKey(editQuestionDto.Type))
                {
                    // Iterate through the list of questions associated with the type
                    foreach (var question in additionalQuestions[editQuestionDto.Type])
                    {
                        // Check if the question has the matching ID
                        if (question.Id == editQuestionDto.QuestionId)
                        {
                            // Update the title of the question
                            question.Title = editQuestionDto.Title;
                            isUpdated = true;
                            break;
                        }
                    }
                }


                //if question is not yet updated, check here
                if (isUpdated == false)
                {
                    var personalInformation = program.PersonalInformation;
                    if (personalInformation.ContainsKey(editQuestionDto.Type))
                    {                      
                        foreach (var question in personalInformation[editQuestionDto.Type])
                        {                           
                            if (question.Id == editQuestionDto.QuestionId)
                            {                                
                                question.Title = editQuestionDto.Title;
                                break;
                            }
                        }
                    }


                }

                var response = await _programRepository.UpdateProgramAsync(editQuestionDto.ProgramId, program);
                if (response != null)
                    return new Response<string>("Question was updated successfully");

            }
            return new Response<string>("Question was not updated.", false);

        }
    }
}
