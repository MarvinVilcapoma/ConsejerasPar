using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Participant : User
    {
        /*public int ParticipantId { get; set; }*/
        public string WicId { get; set; }

        /*[Column(TypeName = "datetime2(0)")]
        public DateTime CreatedOn { get; set; }
        [DefaultValue("true")]
        public bool Enabled { get; set; }*/

    }
}
