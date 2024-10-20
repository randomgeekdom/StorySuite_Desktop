namespace StorySuite.Models
{
    public class StoryProject : Entity
    {
        private StoryProject(string name)
        { this.Name = name; }

        public string Name { get; private set; }

        public static StoryProject TryCreate(string name)
        {
            return new StoryProject(name);
        }
    }
}