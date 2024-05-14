using AutoMapper;
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


        //create a new program
        public async Task<Response<InternshipProgramDto>> CreateProgram(CreateProgramDto programDto)
        {
            var program = _mapper.Map<InternshipProgram>(programDto);
            var response = await _programRepository.CreateProgramAsync(program);
            if (response != null)
                return new Response<InternshipProgramDto>(_mapper.Map<InternshipProgramDto>(response));
            return new Response<InternshipProgramDto>("Program was not created.", false);
        }

        //get all programs
        public async Task<Response<List<InternshipProgramDto>>> GetPrograms()
        {

            var response = await _programRepository.GetProgramsAsync();
            var programs = response.ToList();
            if (programs != null)
                return new Response<List<InternshipProgramDto>>(_mapper.Map<List<InternshipProgramDto>>(programs));
            return new Response<List<InternshipProgramDto>>("No records found");
        }

        //get a single program
        public async Task<Response<InternshipProgramDto>> GetProgram(string id)
        {

            var program = await _programRepository.GetProgramAsync(id);
            if (program != null)
                return new Response<InternshipProgramDto>(_mapper.Map<InternshipProgramDto>(program));
            return new Response<InternshipProgramDto>("No record found");
        }


        //update program
        public async Task<Response<string>> UpdateProgram(EditQuestionDto editQuestionDto)
        {

            var program = await _programRepository.GetProgramAsync(editQuestionDto.ProgramId);
            if (program != null)
            {
                if (editQuestionDto.IsAdditionalQuestions)
                {
                    var questions = program.AdditionalQuestions;
                    // Check if the question type exists in the dictionary
                    if (questions.ContainsKey(editQuestionDto.Type))
                    {
                        // Iterate through the list of questions associated with the type
                        foreach (var question in questions[editQuestionDto.Type])
                        {
                            // Check if the question has the matching ID
                            if (question.Id == editQuestionDto.QuestionId)
                            {
                                // Update the title of the question
                                question.Title = editQuestionDto.Title;
                                break;
                            }
                        }
                    }


                }

                if (editQuestionDto.IsPersonalInformation)
                {
                    var questions = program.PersonalInformation;
                    // Check if the question type exists in the dictionary
                    if (questions.ContainsKey(editQuestionDto.Type))
                    {
                        // Iterate through the list of questions associated with the type
                        foreach (var question in questions[editQuestionDto.Type])
                        {
                            // Check if the question has the matching ID
                            if (question.Id == editQuestionDto.QuestionId)
                            {
                                // Update the title of the question
                                question.Title = editQuestionDto.Title;
                                break;
                            }
                        }
                    }


                }

                var response = await _programRepository.UpdateProgramAsync(editQuestionDto.ProgramId, program);
                if (response != null)
                    return new Response<string>("Program was updated successfully");

            }
            return new Response<string>("Program was not updated.", false);

        }
    }
}
