using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSUTW.Models
{
    public class Marks
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