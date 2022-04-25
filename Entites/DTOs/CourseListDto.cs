using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DTOs
{
    public class CourseListDto
    {
        public CourseListDto(int CourseId,string Name,string Summary,string Description,
            string PhotoUrl,decimal Price,decimal? Discount,bool IsFeatured,decimal? Reyting,
            string CategoryName,
            string InstructorName,string InstructorPhoto,DateTime PublishDate)

        {
            this.CourseId = CourseId;
            this.Name = Name;
            this.Summary = Summary;
            this.Description = Description;
            this.PhotoUrl = PhotoUrl;
            this.Price = Price;
            this.Discount = Discount;
            this.IsFeatured = IsFeatured;
            this.Reyting = Reyting;
            this.CategoryName = CategoryName;
            this.InstructorName = InstructorName;
            this.InstructorPhoto = InstructorPhoto;
            this.PublishDate = PublishDate;
            Lessons = new List<LessonDTOs>();
            SpecificationList = new List<SpecificationDTOs>();
        }
        public int CourseId { get; set; }
        public string Name { get; set; } = null!;
        public string Summary { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public bool IsFeatured { get; set; }
        public decimal? Reyting { get; set; }
        public string? TrailerUrl { get; set; }
        public string  CategoryName { get; set; }
        public string InstructorName { get; set; }
        public string? InstructorPhoto { get; set; }
        public DateTime PublishDate { get; set; }
        public List<LessonDTOs>? Lessons { get; set; }
        public List<SpecificationDTOs>? SpecificationList { get; set; }
    }
}
