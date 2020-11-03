using System;
using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        [StringLength(50)]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "Please select Date")]
        public DateTime DateOfBirth { get; set; }
        public bool Married { get; set; }
        [Required(ErrorMessage = "Please enter Phone")]
        [StringLength(50)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter Salary")]
        public decimal Salary { get; set; }
    }
}
