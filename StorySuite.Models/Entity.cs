namespace StorySuite.Models
{
    public abstract class Entity
    {
        public Guid Id { get; } = Guid.NewGuid();

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            var other = obj as Entity;
            return this.Id == other?.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}