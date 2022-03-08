using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Response
{
    public class AuthResponseV1
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public int ExpiresIn { get; set; }
        public DateTime Issued { get; set; }
        public DateTime Expires { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string ErrorDescription { get; set; }
    }
}
