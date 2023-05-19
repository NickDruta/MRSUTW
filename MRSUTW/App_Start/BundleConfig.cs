using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;

namespace MRSUTW
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/styles/homepage").Include(
                "~/Content/pagestyles/Homepage.css"));

            bundles.Add(new StyleBundle("~/styles/signin").Include(
                "~/Content/pagestyles/SignIn.css"));

            bundles.Add(new StyleBundle("~/styles/signup").Include(
                "~/Content/pagestyles/SignUp.css"));

            bundles.Add(new StyleBundle("~/styles/orar").Include(
                "~/Content/pagestyles/Orar.css"));

            bundles.Add(new StyleBundle("~/styles/events").Include(
               "~/Content/pagestyles/Events.css"));

            bundles.Add(new StyleBundle("~/styles/register").Include(
                "~/Content/pagestyles/Register.css"));

            bundles.Add(new StyleBundle("~/styles/adminhome").Include(
                "~/Content/pagestyles/AdminHome.css"));

            bundles.Add(new StyleBundle("~/styles/profile").Include(
                "~/Content/pagestyles/Profile.css"));

            bundles.Add(new StyleBundle("~/styles/header").Include(
                "~/Content/pagestyles/Header.css"));
        }
    }
}
