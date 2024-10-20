namespace StorySuite.Models
{
    public abstract class Entity
    {
        public Guid Guid { get; } = Guid.NewGuid();

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            var other = obj as Entity;
            return this.Guid == other?.Guid;
        }

        public override int GetHashCode()
        {
            return this.Guid.GetHashCode();
        }
    }
}