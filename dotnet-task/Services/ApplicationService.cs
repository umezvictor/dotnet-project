using AutoMapper;
using dotnet_task.Domain.Models;
using dotnet_task.DTO;
using dotnet_task.Repository;
using dotnet_task.Responses;

namespace dotnet_task.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        public ApplicationService(IApplicationRepository applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }


        //create a new application
        public async Task<Response<ApplicationDto>> CreateApplication(CreateApplicationDto applicationDto)
        {
            var application = _mapper.Map<Applications>(applicationDto);
            var response = await _applicationRepository.CreateApplicationAsync(application);
            if (response != null)
                return new Response<ApplicationDto>(_mapper.Map<ApplicationDto>(response));
            return new Response<ApplicationDto>("Application was not created.", false);
        }


    }
}
