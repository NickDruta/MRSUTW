using MRSUTW.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.Domain.Entities.Marks
{
    public class MDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string StudentEmail { get; set; }

        [Required]
        [StringLength(10)]
        public string Obiect { get; set; }

        [Required]
        [StringLength(50)]
        public string TeacherEmail { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime End { get; set; }

        [Required]
        [StringLength(2)]
        public string Value { get; set; }
    }
}
