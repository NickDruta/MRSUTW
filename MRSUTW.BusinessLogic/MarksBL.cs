using MRSUTW.BusinessLogic.Core;
using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.Marks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.BusinessLogic
{
    internal class MarksBL : MarksApi, IMarks
    {
        public List<MarksData> GetMarks()
        {
            return GetMarksAction();
        }
    }
}
