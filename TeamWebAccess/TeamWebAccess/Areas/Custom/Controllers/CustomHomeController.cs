namespace TeamWebAccess.Areas.Custom.Controllers
{
    using System.Web.Mvc;
    using Microsoft.TeamFoundation.Server.WebAccess;
    using Microsoft.TeamFoundation.Server.WebAccess.Routing;
    using TeamWebAccess.Areas.Custom.Models;

    [SupportedRouteArea(CustomAreaRegistration.CustomAreaLevels)]
    public class CustomHomeController : TfsAreaController
    {
        public ActionResult Index(string message)
        {
            var model = new IndexViewModel { Echo = message };

            return this.View("~/Areas/Custom/Views/CustomHome/Index.aspx", model);
        }

        public override string AreaName
        {
            get { return CustomAreaRegistration.CustomAreaName; }
        }
    }
}