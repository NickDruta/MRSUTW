using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MRSUTW.Domain.Enums;

namespace MRSUTW.Domain.Entities.User
{
    public class UDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password cannot be shorter than 8 characters.")]
        public string Password { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastLogin { get; set; }

        [StringLength(30)]
        public string LasIp { get; set; }

        [StringLength(10)]
        public string Group { get; set; }

        public int Year { get; set; }

        [StringLength(10)]
        public string Faculty { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public UCost Cost { get; set; }

        public int GradeBuget { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        public UType Type { get; set; }

        public bool IsVerified { get; set; }
    }
}
