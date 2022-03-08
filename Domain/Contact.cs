using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Contact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactId { get; set; }
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
        public int ContactTypeId { get; set; }
        public string Description { get; set; }
        public ContactType ContactType { get; set; }

        [Column(TypeName = "datetime2(0)")]
        public DateTime CreatedOn { get; set; }

        [Column(TypeName = "datetime2(0)")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime2(0)")]
        public DateTime EndDate { get; set; }

        [DefaultValue("true")]
        public bool Enabled { get; set; }
    }
}
