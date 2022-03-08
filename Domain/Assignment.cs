using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Assignment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssignmentId { get; set; }
        public virtual Participant Participant { get; set; }
        public int? ParticipantId { get; set; }
        public virtual Counselor Counselor { get; set; }
        public int? CounselorId { get; set; }
        [Column(TypeName = "datetime2(0)")]
        public DateTime CreatedOn { get; set; }
        [DefaultValue("true")]
        public bool Enabled { get; set; }
    }
}
