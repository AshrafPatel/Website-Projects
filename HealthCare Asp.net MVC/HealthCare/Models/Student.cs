using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HealthCare.Models
{
    [Table("Student")]
    public class Student
    {
        public Student()
        {

        }

        [Required]
        [StringLength(50)]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Column("LastName")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Column("Address")]
        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(7)]
        [Column("PostalCode")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        [Column("DOB")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date")]
        public DateTime DOB { get; set; }

        [Required]
        [Column("Email")]
        [RegularExpression(@"^([\w]*[\w\.]*(?!\.)@gmail.com)",
            ErrorMessage = "Please enter a valid gmail account")]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [Column("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped] // Does not effect with your database
        [Compare("Password", ErrorMessage = "Password doesn't match.")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(30)]
        [Column("Telephone")]
        [RegularExpression(@"^(1?(-?\d{3})-?)?(\d{3})(-?\d{4})$",
            ErrorMessage = "Please enter a valid phone number")]
        public string Telephone { get; set; }

        [Display(Name = "Program Type")]
        [Column("ProgramType")]
        public string ProgramType { get; set; }

        [Required]
        [Column("ProgramName")]
        [Display(Name = "Program Name")]
        public string ProgramName { get; set; }

        [Required]
        [Column("InstitutionalName")]
        [Display(Name = "Institutional Name")]
        public string InstitutionalName { get; set; }

        [Key]
        [Column("PKey")]
        public int PKey { get; set; }
    }
}