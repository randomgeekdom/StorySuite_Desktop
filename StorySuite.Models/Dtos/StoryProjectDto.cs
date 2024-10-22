namespace StorySuite.Models.Dtos
{
    public record StoryProjectDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}