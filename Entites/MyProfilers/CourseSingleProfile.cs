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
