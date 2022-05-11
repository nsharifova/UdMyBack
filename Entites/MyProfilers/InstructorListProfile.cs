using AutoMapper;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.MyProfilers
{
    public class InstructorListProfile:Profile
    {
        public InstructorListProfile()
        {
            CreateMap<Instructor, InstructorCourseDTO>()
                .ForMember(
                   l => l.InstructorId,
                   g => g.MapFrom(src => src.Id)
                )
                .ForMember(
                   l => l.InstructorName,
                   g => g.MapFrom(src => src.FullName)
                )
                .ForMember(
                   l => l.InstructorPhoto,
                   g => g.MapFrom(src => src.ProfilImg)
                )
                .ForMember(
                   l => l.CourseList,
                   g => g.MapFrom(src => src.Courses)
                );
        }
    }
}
