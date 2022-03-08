using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Response
{
    public class UserResponseV1
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string Email { get; set; }
        public string WicID { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Enabled { get; set; }

    }
}
