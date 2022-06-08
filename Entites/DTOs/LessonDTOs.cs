using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DTOs
{
    public class LessonDTOs
    {
        public int LessonId { get; set; }
        public string Name { get; set; } = null!;
        public List<LessonVideo> LessonVideos { get; set; }
    }
}
