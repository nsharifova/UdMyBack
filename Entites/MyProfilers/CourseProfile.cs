using AutoMapper;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.MyProfilers
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseListDto>()
                .ForMember(
                    dest => dest.CourseId,
                    opt => opt.MapFrom(src => src.Id)
                    )
                .ForMember(
                    dest => dest.CourseName,
                    opt => opt.MapFrom(src => src.Name)
                    )

                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => src.Description)
                    )

                .ForMember(
                    dest => dest.InstructorName,
                    opt => opt.MapFrom(src => src.Instructor.FullName)
                 )
                .ForMember(
                    dest => dest.InstructorPhoto,
                    opt => opt.MapFrom(src => src.Instructor.ProfilImg)
                    )

                 .ForMember(
                    dest => dest.Price,
                    opt => opt.MapFrom(src => src.Price)
                    )
                 .ForMember(
                    dest => dest.Discount,
                    opt => opt.MapFrom(src => src.Discount)
                    )
                 .ForMember(
                    dest => dest.PublishDate,
                    opt => opt.MapFrom(src => src.PublishDate)
                    )
                 .ForMember(
                    dest => dest.CategoryName,
                    opt => opt.MapFrom(src => src.Category.Name)
                    )

                 .ForMember(
                    dest => dest.Summary,
                    opt => opt.MapFrom(src => src.Summary)
                    )

                 .ForMember(
                    dest => dest.IsFeatured,
                    opt => opt.MapFrom(src => src.IsFeatured)
                    )

                 .ForMember(
                    dest => dest.Reyting,
                    opt => opt.MapFrom(src => src.Reyting)
                    )
                 .ForMember(
                    dest => dest.Lessons,
                    opt => opt.MapFrom(src => 
                    src.Lessons.Select(c=>new LessonDTOs { LessonId=c.Id,Name=c.Name}))
                    )
                 .ForMember(
                    dest => dest.SpecificationList,
                    opt => opt.MapFrom(src => src.CourseSpecifactions.Select(cs=>new SpecificationDTOs
                    {
                        Icon=cs.Specifaction.Icon,
                        Value=cs.Specifaction.Value
                    }))
                    );
        }
    }
}
