using dotnet_task.DTO;
using dotnet_task.Responses;
using dotnet_task.Services;
using Microsoft.AspNetCore.Mvc;


namespace dotnet_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramService _programService;
        private readonly IApplicationService _applicationService;

        public ProgramController(IProgramService programService, IApplicationService applicationService)
        {
            _programService = programService;
            _applicationService = applicationService;
        }


        // GET: api/<ProgramController>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Response<List<InternshipProgramDto>>))]
        public async Task<IActionResult> GetPrograms()
        {
            return Ok(await _programService.GetPrograms());
        }

        // GET api/<ProgramController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Response<InternshipProgramDto>))]    
        public async Task<ActionResult> Get(string id)
        {
            return Ok(await _programService.GetProgram(id));
            
        }

              
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Response<InternshipProgramDto>))]
        public async Task<ActionResult> Post([FromBody] CreateProgramDto programDto)
        {
            var response = await _programService.CreateProgram(programDto);
            if(response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }

       
        [HttpPut("question")]     
        [ProducesResponseType(200, Type = typeof(Response<string>))]
        public async Task<ActionResult> Put([FromBody] EditQuestionDto editQuestionDto)
        {
            var response = await _programService.UpdateProgram(editQuestionDto);
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }


       
        [HttpPost("apply")]
        [ProducesResponseType(200, Type = typeof(Response<ApplicationDto>))]
        public async Task<ActionResult> Apply([FromBody] CreateApplicationDto applicationDto)
        {
            var response = await _applicationService.CreateApplication(applicationDto);
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
