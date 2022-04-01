using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICourseSpecifactionManager
    {
        List<CourseSpecifaction> GetAll();
        void Add(CourseSpecifaction courseSpecifaction);
        void Remove(int id);
        void Update(CourseSpecifaction courseSpecifaction);


    }
}
