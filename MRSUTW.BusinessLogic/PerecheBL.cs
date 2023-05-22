using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRSUTW.BusinessLogic.Core;
using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.Pereche;

namespace MRSUTW.BusinessLogic
{
    internal class PerecheBL: PerecheApi, IPereche
    {
        public List<PerecheData> getOrar()
        {
            return getOrarAction();
        }

        public List<PerecheData> getOrarToday()
        {
            return getOrarTodayAction();
        }

        public List<PerecheData> getRegister()
        {
            return getRegisterAction();
        }
    }
}
