using Ardalis.Result;
using StorySuite.Models.Dtos;

namespace StorySuite.Models
{
    public class StoryProject : Entity
    {
        private StoryProject(string name, string? filePath)
        {
            this.Name = name;
            this.FilePath = filePath;
        }

        public string? FilePath { get; private set; }
        public string Name { get; private set; }

        public static Result<StoryProject> TryCreate(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Result.Invalid(new ValidationError($"{nameof(name)} must contain a value"));
            }

            return new StoryProject(name, null);
        }

        public static Result<StoryProject> TryLoad(StoryProjectDto dto, string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return Result.Invalid(new ValidationError($"{nameof(filePath)} must contain a value"));
            }

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                return Result.Invalid(new ValidationError($"{nameof(dto.Name)} must have a vallue"));
            }

            return new StoryProject(dto.Name, filePath);
        }

        public StoryProjectDto ToDto()
        {
            return new StoryProjectDto
            {
                Id = this.Id,
                Name = this.Name
            };
        }
    }
}