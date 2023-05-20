using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRSUTW.BusinessLogic.DBModel;
using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.Pereche;
using MRSUTW.Domain.Enums;

namespace MRSUTW.BusinessLogic.Core
{
    internal class PerecheApi
    {
        public List<PerecheData> getOrarAction()
        {
            List<PerecheData> perechi = new List<PerecheData>();

            using (var db = new UserContext())
            {
                var perechiList = db.Perechi.ToList();

                foreach (var pereche in perechiList)
                {
                    var perecheData = new PerecheData
                    {
                        Start = pereche.Start,
                        End = pereche.End,
                        TypeOfDay = pereche.TypeOfDay,
                        WeekType = pereche.WeekType,
                        ObiectType = pereche.ObiectType,
                        Obiect = pereche.Obiect,
                        Profesor = pereche.Profesor,
                        Grupa = pereche.Grupa,
                        Cabinet = pereche.Cabinet,
                    };

                    perechi.Add(perecheData);
                }
            }

            return perechi;
        }

        public List<PerecheData> getRegisterAction()
        {
            PerecheData pereche1 = new PerecheData();

            pereche1.Id = 0;
            pereche1.Start = DateTime.Now;
            pereche1.End = DateTime.Now;
            pereche1.WeekType = PType.Ambele;
            pereche1.Obiect = "Tw";
            pereche1.Profesor = "Dragos Strainu";
            pereche1.Cabinet = 518;
            List<PerecheData> Register = new List<PerecheData>();
            Register.Add(pereche1);

            return Register;
        }
    }
}
