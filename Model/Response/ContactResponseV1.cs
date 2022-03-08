using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Response
{
    public class ContactResponseV1
    {
        public int ContactId { get; set; }
        public int AssignmentId { get; set; }
        public AssignmentResponseV1 Assignment { get; set; }
        public int ContactTypeId { get; set; }
        public string Description { get; set; }
        public ContactTypeResponseV1 ContactType { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Enabled { get; set; }
    }
}
