using Core.Abstract;

namespace Entites
{
    public class OrderItem : IEntity
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        public int CourseId { get; set; }
        public bool IsRefunded { get; set; }
        //public virtual Course? Course { get; set; }
    }
}
