using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public class AuthorizeEmailDomainAttribute : AuthorizeAttribute
{
    protected override bool AuthorizeCore(HttpContextBase httpContext)
    {
        var isAuthorized = base.AuthorizeCore(httpContext);
        if (!isAuthorized)
        {
            return false;
        }

        bool isGoodDomain = httpContext.User.Identity.Name.Contains("@admin.com");
        return isGoodDomain;
    }
}