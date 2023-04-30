using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.Pereche;

namespace MRSUTW.BusinessLogic.Core
{
    internal class PerecheApi
    {
        public List<PerecheData> getOrarAction()
        {
            PerecheData pereche1 = new PerecheData();

            pereche1.Id = 0;
            pereche1.start = DateTime.Now.ToString("HH:mm");
            pereche1.end = DateTime.Now.AddMinutes(90).ToString("HH:mm");
            pereche1.typeOfDay = "Luni";
            pereche1.obiect = "Tw";
            pereche1.profesor = "Dragos Strainu";
            pereche1.cabinet = 518;
            pereche1.value = "a";
            List<PerecheData> Orar = new List<PerecheData>();
            Orar.Add(pereche1);

            return Orar; 
        }

        public List<PerecheData> getRegisterAction()
        {
            PerecheData pereche1 = new PerecheData();

            pereche1.Id = 0;
            pereche1.start = DateTime.Now.ToString("HH:mm");
            pereche1.end = DateTime.Now.AddMinutes(90).ToString("HH:mm");
            pereche1.typeOfDay = "Luni";
            pereche1.obiect = "Tw";
            pereche1.profesor = "Dragos Strainu";
            pereche1.cabinet = 518;
            pereche1.value = "a";
            List<PerecheData> Register = new List<PerecheData>();
            Register.Add(pereche1);

            return Register;
        }
    }
}
