using MRSUTW.Domain.Entities.Marks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.BusinessLogic.Interfaces
{
    public interface IMarks
    {
        List<MarksData> GetMarks();
    }
}
