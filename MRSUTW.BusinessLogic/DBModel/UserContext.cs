using MRSUTW.Domain.Entities.Pereche;
using MRSUTW.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.BusinessLogic.DBModel
{
    public class UserContext : DbContext
    {
        public UserContext() :
             base("name=MRSUTWDB")
        { }

        public virtual DbSet<UDbTable> Users { get; set; }
        public virtual DbSet<SessionsDbTable> Sessions { get; set; }
        public virtual DbSet<PDbTable> Perechi { get; set; }
    }
}
