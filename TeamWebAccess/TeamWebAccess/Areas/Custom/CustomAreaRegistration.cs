namespace TeamWebAccess.Areas.Custom
{
    using System.Web.Mvc;

    using Microsoft.TeamFoundation.Server.WebAccess;
    using Microsoft.TeamFoundation.Server.WebAccess.Routing;

    using TeamWebAccess.Areas.Custom.Controllers;

    public class CustomAreaRegistration : AreaRegistration
    {
        public const NavigationContextLevels CustomAreaLevels = NavigationContextLevels.Project | NavigationContextLevels.Team;
        public const string CustomAreaName = "Custom";

        public override string AreaName
        {
            get
            {
                return CustomAreaName;
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            // NOTE: you can also setup your IoC and register any script/style bundles
            NavigationTable.Hubs.Add(CreateHub());
            context.Namespaces.Add("TeamWebAccess.Areas.Custom.Controllers");
        }

        private static NavigationHub CreateHub()
        {
            var customHub = new NavigationHub { NavigationLevels = CustomAreaLevels, QueryStatusCallback = OnQueryStatusCallback };
            return customHub;
        }

        private static NavigationHubStatus OnQueryStatusCallback(
            NavigationHub hub,
            TfsWebContext tfsWebContext,
            ControllerBase controller)
        {
            if (tfsWebContext == null)
            {
                return null;
            }

            // this gets the appropriate route name for the NavigationContextLevel of the current context.
            var controllerActionRouteName = TfsRouteHelpers.GetControllerActionRouteName(tfsWebContext);

            // builds the ActionLink using that NavigationContextLevel appropriate route
            var actionLink = tfsWebContext.Url.RouteUrl(
                controllerActionRouteName,
                "index",
                "customhome",
                new { routeArea = string.Empty });

            return new NavigationHubStatus(hub)
            {
                HubGroup = WellKnownHubGroup.Custom,
                HubGroupDisplayText = CustomAreaName,
                DisplayText = "Echo",
                CommandId = "Custom.CustomHome.Index",
                Order = 100,
                ActionLink = actionLink,
                ActionArguments = new { message = "None" },
                Selected = controller is CustomHomeController
            };
        }
    }
}