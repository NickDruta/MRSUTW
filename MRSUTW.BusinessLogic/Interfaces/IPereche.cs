using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRSUTW.Domain.Entities.Pereche;

namespace MRSUTW.BusinessLogic.Interfaces
{
    public interface IPereche
    {
        List<PerecheData> getOrar();
        List<PerecheData> getOrarToday();
        List<PerecheData> GetPerechi();
        void AddPereche(PerecheData p);
        void EditPereche(PerecheData p);
        List<PerecheData> RemovePerecheById(int id);
        List<PerecheData> getRegister();
    }
}
