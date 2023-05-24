using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.Domain.Entities.Marks
{
    public class MarksData
    {
        public int Id { get; set; }
        public string StudentEmail { get; set; }
        public string Obiect { get; set; }
        public string TeacherEmail { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Value { get; set; }
    }
}
