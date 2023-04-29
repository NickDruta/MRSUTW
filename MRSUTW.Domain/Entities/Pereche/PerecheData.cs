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
        public string start { get; set; }
        public string end { get; set; }
        public string typeOfDay { get; set; }
        public string obiect { get; set; }
        public string profesor { get; set; }
        public int cabinet { get; set; }
        public string value { get; set; }
    }
}
