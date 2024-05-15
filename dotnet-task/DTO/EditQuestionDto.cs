using System.ComponentModel.DataAnnotations;

namespace dotnet_task.DTO
{
    public class EditQuestionDto
    {
       

        [Required]
        public string ProgramId { get; set; }
        [Required]
        public string QuestionId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Type { get; set; }

        
       
    }
}
