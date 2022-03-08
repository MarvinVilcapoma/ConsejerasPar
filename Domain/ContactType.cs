using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class ContactType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactTypeId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Description { get; set; }

        [Column(TypeName = "datetime2(0)")]
        public DateTime CreatedOn { get; set; }
        [DefaultValue("true")]
        public bool Enabled { get; set; }
    }
}
