using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILessonManager
    {
        List<Lesson> GetAll();
        void Add(Lesson lesson);
        void Update(Lesson lesson);
        void Remove(int id);


    }
}
