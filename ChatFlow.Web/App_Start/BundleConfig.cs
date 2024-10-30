using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ChatFlow.Web.App_Start {
     public class BundleConfig {
          public static void RegisterBundles(BundleCollection bundles) {
               bundles.Add(new StyleBundle("~/assets/vendors")
                    .Include("~/assets/vendors/mdi/css/materialdesignicons.min.css",
                    "~/assets/vendors/css/vendor.bundle.base.css",
                    "~/assets/css/style.css"));

               bundles.Add(new ScriptBundle("~/assets/js")
                    .Include("~/assets/vendors/js/vendor.bundle.base.js",
                    "~/assets/js/off-canvas.js",
                    "~/assets/js/hoverable-collapse.js",
                    "~/assets/js/misc.js",
                    "~/assets/js/settings.js",
                    "~/assets/js/todolist.js"));
          }
     }
}