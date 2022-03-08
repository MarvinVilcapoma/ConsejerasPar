using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Request
{
    public class ContactRequestV1
    {
        public int ContactId { get; set; }
        public int AssignmentId { get; set; }
        public int ContactTypeId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
