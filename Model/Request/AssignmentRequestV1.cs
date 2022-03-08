using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Request
{
    public class AssignmentRequestV1
    {
        public int AssignmentId { get; set; }
        public virtual ParticipantRequestV1 Participant { get; set; }
        public int? ParticipantId { get; set; }
        public virtual CounselorRequestV1 Counselor { get; set; }
        public int? CounselorId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Enabled { get; set; }
    }
}
