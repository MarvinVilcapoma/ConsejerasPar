using Common;
using Common.Generic.HttpHelpers;
using Common.Logging;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Net.Http;

namespace Security.API.Helpers
{
    public class RequestUtility
    {
        private IHttpContextAccessor _contextAccessor;
        private HttpContext _context { get { return _contextAccessor.HttpContext; } }

        public RequestUtility(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public CustomHeader GetHeaders()
        {
            HttpRequestMessage Request = _context.Items["MS_HttpRequestMessage"] as HttpRequestMessage;
            CustomHeader customHeader = new CustomHeader();
            if (Request != null)
            {
                if (Request.Headers != null)
                {
                    string transactionId = string.Empty;
                    if (Request.Headers.Contains(AppConstants.TransactionId))
                    {
                        transactionId = Request.Headers.GetValues(AppConstants.TransactionId).First();
                    }
                    if (Request.Headers.Contains(AppConstants.Origin))
                    {
                        customHeader.Origin = Request.Headers.GetValues(AppConstants.Origin).First();
                    }
                    customHeader.Transaction = transactionId.GetTransaction();
                }
                else
                {
                    customHeader.Transaction = string.Empty.GetTransaction();
                    customHeader.Origin = AppConstants.Unknow;
                }
            }
            else
            {
                customHeader.Transaction = string.Empty.GetTransaction();
                customHeader.Origin = AppConstants.Unknow;
            }
            return customHeader;
        }
    }
}
