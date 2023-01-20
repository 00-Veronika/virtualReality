using Microsoft.AspNetCore.Mvc.Rendering;

namespace virtualReality.Helpers
{
    public static class Utilities
    {
        public static string IsActive(this IHtmlHelper html, string controller, string action)
        {
            var routeData = html.ViewContext.RouteData;

            var routeAction = (string)routeData.Values["action"];
            var routeControl = (string)routeData.Values["controller"];

            var returnActive = controller == routeControl && action == routeAction;

            return returnActive ? "active" : "";
        }

        public static bool IsUserAdmin(string role)
        {
            return string.Equals(role, "admin");
        }
    }
}