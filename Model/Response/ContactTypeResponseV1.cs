using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Response
{
    public class ContactTypeResponseV1
    {
        public int ContactTypeId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Enabled { get; set; }
    }
}
