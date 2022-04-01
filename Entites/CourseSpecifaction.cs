using Core.Abstract;

namespace Entites
{
    public class CourseSpecifaction : IEntity
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int SpecifactionId { get; set; }
        public virtual Specifaction Specifaction { get; set; }
    }
}
