using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MRSUTW.Domain.Enums;

namespace MRSUTW.Domain.Entities.Pereche
{
    public class PDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime End { get; set; }

        public int TypeOfDay { get; set; }

        public PType WeekType { get; set; }

        [StringLength(2)]
        public string ObiectType { get; set; }

        [StringLength(10)]
        public string Obiect { get; set; }

        [StringLength(50)]
        public string Profesor { get; set; }

        [StringLength(10)]
        public string Grupa { get; set; }

        public int Cabinet { get; set; }
    }
}
