using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string SecondName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string FirstLastName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string SecondLastName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string UserName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Password { get; set; }
        [Column(TypeName = "datetime2(0)")]
        public DateTime CreatedOn { get; set; }

        /*public Participant Participant { get; set; }*/

        [DefaultValue("true")]
        public bool Enabled { get; set; }
    }
}
