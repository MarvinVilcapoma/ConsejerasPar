using Common;
using Common.AspNetCore.UserAgent;
using Common.Generic.HttpHelpers;
using Common.Logging;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

public class RequestHelpers
{
    private IHttpContextAccessor _contextAccessor;

    private HttpContext _context { get { return _contextAccessor.HttpContext; } }

    public RequestHelpers(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public string AuditUserData(CustomHeader header)
    {
        string userData = string.Empty;
        try
        {
            var origen = header.Origin.GetOrigin();
            if (String.IsNullOrEmpty(origen)) origen = "Unknow";
            userData = "Origen: [" + origen + "] Browser: [" + Browser() + "]";
        }
        catch
        {
            userData = "Origen: [" + "Unknow" + "] Browser: [" + "Unknow" + "]";
        }
        return userData;
    }

    public string UserName()
    {

        var userName = "SystemGenerated";
        // Figure out the user's identity
        if (_context != null)
        {
            if (_context.User != null)
            {
                var identity = _context.User.Identity;

                if (identity != null && identity.IsAuthenticated)
                {
                    userName = identity.Name;
                }
            }
        }

        return userName;
    }

    public string Browser()
    {
        // Figure out the user's identity
        if (_context != null)
        {
            var _useragent = _context.Request.Headers["User-Agent"].FirstOrDefault();
            UserAgent ua = new UserAgent(_useragent);
            return ua.Browser.Name + ua.Browser.Version;
        }
        else return "Unknow";
    }
}

