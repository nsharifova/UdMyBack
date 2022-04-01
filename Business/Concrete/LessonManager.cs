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
    public class LessonManager : ILessonManager
    {
        private readonly ILessonDal _lessonDal;

        public LessonManager(ILessonDal lessonDal)
        {
            _lessonDal = lessonDal;
        }

        public void Add(Lesson lesson)
        {
            _lessonDal.Add
                (lesson);

        }

        public List<Lesson> GetAll()
        {
            return _lessonDal.GetAll(); 
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Lesson lesson)
        {
            throw new NotImplementedException();
        }
    }
}
