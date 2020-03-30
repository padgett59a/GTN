using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GlobalTeamNetwork.Models
{
    public class ViewBagFilter : IActionFilter
    {
        private static readonly string Enabled = "Enabled";
        private static readonly string Disabled = string.Empty;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Controller is Controller controller)
            {
                // GlobalTeamNetwork Toggle Features
                controller.ViewBag.AppSidebar = Enabled;
                controller.ViewBag.AppHeader = Enabled;
                controller.ViewBag.AppLayoutShortcut = Enabled;
                controller.ViewBag.AppFooter = Enabled;
                controller.ViewBag.ShortcutMenu = Enabled;
                controller.ViewBag.ChatInterface = Enabled;
                controller.ViewBag.LayoutSettings = Enabled;

                // GlobalTeamNetwork Default Settings
                controller.ViewBag.App = "GlobalTeamNetwork";
                controller.ViewBag.AppName = "Global Team Network";
                controller.ViewBag.AppFlavor = "ASP.NET Core 3.1";
                controller.ViewBag.AppFlavorSubscript = ".NET Core 3.1";
                controller.ViewBag.User = "Dr. Codex Lantern";
                controller.ViewBag.Email = "drlantern@gotbootstrap.com";
                controller.ViewBag.Twitter = "codexlantern";
                controller.ViewBag.Avatar = "avatar-admin.png";
                controller.ViewBag.Version = "4.0.2";
                controller.ViewBag.Bs4v = "4.3";
                controller.ViewBag.Logo = "logo.png";
                controller.ViewBag.LogoM = "logo.png";
                controller.ViewBag.Copyright = "2020 © GlobalTeamNetwork by&nbsp;<a href='https://www.ckwyand.com' class='text-primary fw-500' title='gotbootstrap.com' target='_blank'>ckwyand.com</a>";
                controller.ViewBag.CopyrightInverse = "2020 © GlobalTeamNetwork by&nbsp;<a href='https://www.www.ckwyand.com' class='text-white opacity-40 fw-500' title='gotbootstrap.com' target='_blank'>ckwyand.com</a>";
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
