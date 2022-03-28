using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class EResponseBase<TEntity> : ICloneable where TEntity : class, new()
    {
        public int? Code { get; set; }
        public string Message { get; set; }
        public string MessageEN { get; set; }
        public bool IsResultList { get; set; } = false;
        public IEnumerable<TEntity> listado { get; set; }
        public TEntity objeto { get; set; }
        public string dato { get; set; }
        public Exception TechnicalErrors { get; set; }
        public List<string> FunctionalErrors { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return string.Format("Response[Code: {0}, Message: {1},  listado: {2} , objeto {3}]", Code, Message, listado, objeto);
        }

    }

    public class EResponseBase
    {
        public int? Code { get; set; }
        public string Message { get; set; }
        public string MessageEN { get; set; }
        public bool blnResult { get; set; } = false;
        public string strResult { get; set; }
        public string strToken { get; set; }
        public object objResult { get; set; }
        /*public Exception TechnicalErrors { get; set; }
        public List<string> FunctionalErrors { get; set; }*/

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return string.Format("Response[Code: {0}, Message: {1},  bool: {2} , string {3}, object {4}]", Code, Message, blnResult, strResult, objResult);
        }

    }

    public class EResponseOBase<Object>
    {
        public int? Code { get; set; }
        public string Message { get; set; }
        public string MessageEN { get; set; }
        public bool blnResult { get; set; } = false;
        public string strResult { get; set; }
        public Object objResult { get; set; }
        /*public Exception TechnicalErrors { get; set; }
        public List<string> FunctionalErrors { get; set; }*/

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return string.Format("Response[Code: {0}, Message: {1},  bool: {2} , string {3}, object {4}]", Code, Message, blnResult, strResult, objResult);
        }

    }
}
