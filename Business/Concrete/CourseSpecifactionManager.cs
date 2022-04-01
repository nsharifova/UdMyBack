using Business.Abstract;
using DataAccess.Abstract;
using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CourseSpecifactionManager : ICourseSpecifactionManager
    {
        private readonly ICourseSpecifactionDal _dal;

        public CourseSpecifactionManager(ICourseSpecifactionDal dal)
        {
            _dal = dal;
        }

        public void Add(CourseSpecifaction courseSpecifaction)
        {
            _dal.Add(courseSpecifaction);

        }

        public List<CourseSpecifaction> GetAll()
        {
           return _dal.GetAll();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CourseSpecifaction courseSpecifaction)
        {
            throw new NotImplementedException();
        }
    }
}
