using Core.Abstract;

namespace Entites
{
    public class Category:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? PublishDate { get; set; }
        public DateTime? ModifadeOn { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsDeleted { get; set; }
        public int? ParentCategoryId { get; set; }
        public virtual Category? ParentCategory  { get; set; }
    }
}
