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
                controller.ViewBag.AppFlavor = "Beta";
                controller.ViewBag.AppFlavorSubscript = "";
                //controller.ViewBag.User = "GTN Admin";
                //controller.ViewBag.Email = "gtnadmin@ckwyand.com";
                controller.ViewBag.Twitter = "";
                controller.ViewBag.Avatar = "avatar-m.png";
                controller.ViewBag.Version = "4.0.2";
                controller.ViewBag.Bs4v = "4.3";
                controller.ViewBag.Logo = "";
                controller.ViewBag.LogoM = "logo.png";
                controller.ViewBag.Copyright = "2020 © GlobalTeamNetwork by&nbsp;<a href='http://www.ckwyand.com' class='text-primary fw-500' title='ckwyand.com' target='_blank'>ckwyand.com</a>";
                controller.ViewBag.CopyrightInverse = "2020 © GlobalTeamNetwork by&nbsp;<a href='http://www.ckwyand.com' class='text-white opacity-40 fw-500' title='ckwyand.com' target='_blank'>ckwyand.com</a>";
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
