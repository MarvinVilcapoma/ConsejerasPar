﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Request
{
    public class CounselorRequestV2
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string Email { get; set; }
        public string WicId { get; set; }
    }
}
