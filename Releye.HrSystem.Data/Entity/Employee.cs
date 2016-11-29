using GoTech.Framework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Releye.HrSystem.Data.Entity
{
    public class Employee : BaseGoTechEntity
    {
        public Employee()
        {

        }
        [Required]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public DateTime JoinDate { get; set; }

        public long GenderID { get; set; }

        [ForeignKey("GenderID")]
        public virtual Domain Gender { get; set; }

    }
}
