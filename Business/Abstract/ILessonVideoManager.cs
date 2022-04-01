using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILessonVideoManager
    {
        List<LessonVideo> GetAll();
        void Add(LessonVideo lessonvideo);
        void Remove(int id);
        void Update(LessonVideo lessonvideo);

    }
}
