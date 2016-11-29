using GoTech.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace Releye.HrSystem.Data.Entity
{
    public class Dependent : BaseGoTechEntity
    {
        public string Name { get; set; }

        public long EmployeeID { get; set; }

        public long GenderID { get; set; }

        public long RelationshipID { get; set; }

        [ForeignKey("RelationshipID")]
        public virtual Domain Relationship { get; set; }

        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("GenderID")]
        public virtual Domain Gender { get; set; }

    }
}
