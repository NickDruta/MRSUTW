using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using MRSUTW.BusinessLogic.DBModel;
using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.Event;
using MRSUTW.Domain.Entities.Pereche;
using MRSUTW.Domain.Entities.User;
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

        public List<PerecheData> getOrarTodayAction()
        {
            DateTime today = new DateTime();
            List<PerecheData> perechi = new List<PerecheData>();

            using (var db = new UserContext())
            {
                var perechiList = db.Perechi.ToList();

                foreach (var pereche in perechiList)
                {
                    if (pereche.Start.ToShortDateString() == today.ToShortDateString()) {
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
            }

            return perechi;
        }

        internal List<PerecheData> GetPerechiAction()
        {
            List<PerecheData> perechi = new List<PerecheData>();

            using (var db = new UserContext())
            {
                var perecheList = db.Perechi.ToList();

                foreach (var pereche in perecheList)
                {
                    var perecheData = new PerecheData
                    {
                        Id = pereche.Id,
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

        public void AddPerecheAction(PerecheData p)
        {
            PDbTable pDb = new PDbTable
            {
                Id = p.Id,
                Start = p.Start,
                End = p.End,
                TypeOfDay = p.TypeOfDay,
                WeekType= p.WeekType,
                ObiectType= p.ObiectType,
                Obiect= p.Obiect,
                Profesor= p.Profesor,
                Grupa= p.Grupa,
                Cabinet= p.Cabinet,
            };
            using (var db = new UserContext())
            {
                db.Perechi.Add(pDb);
                db.SaveChanges();
            }
        }

        public void EditPerecheAction(PerecheData p)
        {
            using (var db = new UserContext())
            {
                var pereche = db.Perechi.Find(p.Id);
                if (pereche != null)
                {
                    pereche.Id = p.Id;
                    pereche.Start = p.Start;
                    pereche.End = p.End;
                    pereche.TypeOfDay = p.TypeOfDay;
                    pereche.WeekType = p.WeekType;
                    pereche.ObiectType = p.ObiectType;
                    pereche.Obiect = p.Obiect;
                    pereche.Profesor = p.Profesor;
                    pereche.Grupa = p.Grupa;
                    pereche.Cabinet = p.Cabinet;

                    db.SaveChanges();
                }
            }
        }

        public List<PerecheData> RemovePerecheByIdAction(int id)
        {
            using (var db = new UserContext())
            {
                var perecheDb = db.Perechi.Find(id);
                if (perecheDb != null)
                {
                    db.Perechi.Remove(perecheDb);
                    db.SaveChanges();
                }

                List<PerecheData> perechiList = new List<PerecheData>();

                var perecheDbList = db.Perechi.ToList();

                foreach (var p in perecheDbList)
                {
                    var pDb = new PerecheData
                    {
                        Id = p.Id,
                        Start = p.Start,
                        End = p.End,
                        TypeOfDay = p.TypeOfDay,
                        WeekType = p.WeekType,
                        ObiectType = p.ObiectType,
                        Obiect = p.Obiect,
                        Profesor = p.Profesor,
                        Grupa = p.Grupa,
                        Cabinet = p.Cabinet,
                    };

                    perechiList.Add(pDb);
                }

                return perechiList;
            }
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
