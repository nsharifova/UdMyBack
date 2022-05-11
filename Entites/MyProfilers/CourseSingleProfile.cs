using AutoMapper;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.MyProfilers
{
    public class CourseSingleProfile:Profile
    {
        public CourseSingleProfile()
        {
            CreateMap<CourseDTOs, Course>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                    )
                .ForMember(
                    dest => dest.Summary,
                    opt => opt.MapFrom(src => src.Summary)
                    )
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => src.Description)
                    )
                .ForMember(
                    dest => dest.PhotoUrl,
                    opt => opt.MapFrom(src => src.PhotoUrl)
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
                    dest => dest.IsFeatured,
                    opt => opt.MapFrom(src => src.IsFeatured)
                    )
                 .ForMember(
                    dest => dest.Reyting,
                    opt => opt.MapFrom(src => src.Reyting)
                    )
                 .ForMember(
                    dest => dest.TrailerUrl,
                    opt => opt.MapFrom(src => src.TrailerUrl)
                    )
                .ForMember(
                    dest => dest.CategoryId,
                    opt => opt.MapFrom(src => src.CategoryId)
                    )
                 .ForMember(
                    dest => dest.InstructorId,
                    opt => opt.MapFrom(src => src.InstructorId)
                    )
                 .ForMember(
                    dest => dest.Lessons,
                    opt => opt.MapFrom(src => src.Lessons
                    .Select(c => new Lesson { Name = c.Name, LessonVideos = new List<LessonVideo>() })))
                 .ForMember(
                    dest => dest.CourseSpecifactions,
                    opt => opt.MapFrom(src => src.SpecificationDTOs.Select(sp =>
                        new CourseSpecifaction { Specifaction=
                            new Specifaction { Icon=sp.Icon,Value=sp.Value} }
                    ).ToArray()
                    )); 
        }       
    }
}
