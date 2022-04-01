using Core.Abstract;

namespace Entites
{
    public class Specifaction : IEntity
    {
        public int Id { get; set; }
        public string? Icon { get; set; }
        public string Value { get; set; } = null!;

    }
}
