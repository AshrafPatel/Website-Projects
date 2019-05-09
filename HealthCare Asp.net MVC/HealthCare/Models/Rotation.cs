using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HealthCare.Models
{
    [Table("Rotation")]
    public class Rotation
    {
        public Rotation()
        {

        }

        [ForeignKey("Student")]
        [Key]
        [Column("PKey")]
        public int PKey { get; set; }
        public virtual Student Student { get; set; }

        [Required]
        [Column("RotationName")]
        [Display(Name = "Rotation Name")]
        public string RotationName { get; set; }

        [Required]
        [Column("StartDate")]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public string StartDate { get; set; }

        [Required]
        [Column("EndDate")]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public string EndDate { get; set; }

        [Required]
        [Column("Supervisor")]
        public string Supervisor { get; set; }

        public int RKey { get; set; }
    }
}