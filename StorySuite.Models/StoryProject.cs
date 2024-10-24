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

        /// <summary>
        /// Use this when adding a new project
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Result<StoryProject> TryCreate(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                var nameText = nameof(name);
                return GetRequireValueError(nameText);
            }

            return new StoryProject(name, null);
        }

        /// <summary>
        /// Use this when loading an existing project
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static Result<StoryProject> TryLoad(StoryProjectDto dto, string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return GetRequireValueError(nameof(filePath));
            }

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                return GetRequireValueError(nameof(dto.Name));
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

        private static Result<StoryProject> GetRequireValueError(string nameText)
        {
            return Result.Invalid(new ValidationError($"{nameText} must contain a value"));
        }
    }
}