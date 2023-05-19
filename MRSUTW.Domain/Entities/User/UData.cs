using MRSUTW.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.Domain.Entities.User
{
    public class UData
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Group { get; set; }
        public int Year { get; set; }
        public string Faculty { get; set; }
        public string PhoneNumber { get; set; }
        public UCost Cost { get; set; }
        public int GradeBuget { get; set; }
        public DateTime Birthday { get; set; }
        public UType Type { get; set; }
        public bool IsVerified { get; set; }
    }
}
