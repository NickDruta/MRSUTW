using MRSUTW.BusinessLogic.DBModel;
using MRSUTW.Domain.Entities.Marks;
using MRSUTW.Domain.Entities.Pereche;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MRSUTW.BusinessLogic.Core
{
    internal class MarksApi
    {
        internal List<MarksData> GetMarksAction()
        {
            List<MarksData> marks = new List<MarksData>();

            using (var db = new UserContext())
            {
                var marksList = db.Marks.ToList();

                foreach (var mark in marksList)
                {
                    var markData = new MarksData
                    {
                        Id = mark.Id,
                        StudentEmail = mark.StudentEmail,
                        Obiect = mark.Obiect,
                        TeacherEmail = mark.TeacherEmail,
                        Start = mark.Start,
                        End = mark.End,
                        Value = mark.Value,
                    };

                    marks.Add(markData);
                }
            }

            return marks;
        }
    }
}
