using ChatFlow.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Optimization;
using AutoMapper;
using ChatFlow.Domains.Entities;
using ChatFlow.Web.ViewModels;

namespace ChatFlow.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
               InitializeAutoMapper();
            // Code that runs on application startup
           AreaRegistration.RegisterAllAreas();
           RouteConfig.RegisterRoutes(RouteTable.Routes);
           BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
          protected static void InitializeAutoMapper()
          {
               Mapper.Initialize(cfg =>
               {
                    cfg.CreateMap<LoginViewModel, ULoginData>();
                    //cfg.CreateMap<UserRegister, URegisterData>();
                    cfg.CreateMap<User, UserMinimal>();


               });
          }
     }

}