using MRSUTW.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.Domain.Entities.Event
{
     public class EDbTable
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }

          [StringLength(50)]
          public string Title { get; set; }

          [StringLength(300)]
          public string Description { get; set; }

          [Required]
          [DataType(DataType.Date)]
          public DateTime Created { get; set; }

     }
}
