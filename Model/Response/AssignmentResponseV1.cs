using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Response
{
    public class AssignmentResponseV1
    {
        public int AssignmentId { get; set; }
        public virtual ParticipantResponseV1 Participant { get; set; }
        public int? ParticipantId { get; set; }
        public virtual CounselorResponseV1 Counselor { get; set; }
        public int? CounselorId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Enabled { get; set; }
    }
}
