using Core.Abstract;

namespace Entites
{
    public class Instructor : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }=null!;
        public string ProfilImg { get; set; }
        public virtual List<Course>? Courses { get; set; }
    }
}
