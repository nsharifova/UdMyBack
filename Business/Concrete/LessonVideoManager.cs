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
    public class LessonVideoManager : ILessonVideoManager
    {
        private readonly ILessonVideoDal _dal;

        public LessonVideoManager(ILessonVideoDal dal)
        {
            _dal = dal;
        }
        
        public void Add(LessonVideo lessonvideo)
        {
            _dal.Add(lessonvideo);
        }

        public List<LessonVideo> GetAll()
        {
            return _dal.GetAll();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(LessonVideo lessonvideo)
        {
            throw new NotImplementedException();
        }
    }
}
