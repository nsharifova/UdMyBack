using Core.Abstract;

namespace Entites
{
    public class LessonVideo : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; } 
        public string VideoURl { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public int LessonId { get; set; }
    }
}
