﻿using MRSUTW.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.Domain.Entities.Pereche
{
    public class PerecheData
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int TypeOfDay { get; set; }
        public PType WeekType { get; set; }
        public string ObiectType { get; set; }
        public string Obiect { get; set; }
        public string Profesor { get; set; }
        public string Grupa { get; set; }
        public int Cabinet { get; set; }
    }
}
