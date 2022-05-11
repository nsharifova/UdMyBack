using Business.Abstract;
using DataAccess.Abstract;
using Entites;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class InstructorManager : IInstructorManager
    {
        private readonly IInstructorDal _dal;

        public InstructorManager(IInstructorDal dal)
        {
            _dal = dal;
        }

        public void Add(Instructor instructor)
        {
            _dal.Add(instructor);
        }

        public List<Instructor> GetAll()
        {
            return _dal.GetAll();
        }

        public Instructor? GetCourseForInstructor(int instructorId)
        {
          return  _dal.InstructorCoursesById(instructorId);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Instructor instructor)
        {
            throw new NotImplementedException();
        }
    }
}
