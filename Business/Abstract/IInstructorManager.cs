using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IInstructorManager
    {
        List<Instructor> GetAll();
        void Add(Instructor instructor);
        void Update(Instructor instructor);
        void Remove(int id);

    }
}
