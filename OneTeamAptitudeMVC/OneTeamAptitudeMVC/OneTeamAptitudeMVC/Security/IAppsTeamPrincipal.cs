using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace OneTeamAptitudeMVC.Web.Security
{
    public interface IAppsTeamPrincipal : IPrincipal
    {   
        new bool IsInRole(string role);
    }
}