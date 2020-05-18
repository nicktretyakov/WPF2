﻿using Ecours.Account.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.ServiceModel;
using System.Windows;
using Ecours.Utils.Logging;
using System.Configuration;
using System.Collections;
using Ecours.Account.ViewsModel;

namespace Ecours.Account
{
    public class ModuleAccount : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            if (AccountVM.TestService())
            {
                IRegionManager regionManager = containerProvider.Resolve<IRegionManager>();

                // IRegion region = regionManager.Regions["WorkspaceRegion"];
                // region.RemoveAll();

                //We get from the container an instance of AccountGrid.
                AccountGrid view = containerProvider.Resolve<AccountGrid>();

                //We get from the region manager our target region.
                IRegion region = regionManager.Regions["WorkspaceRegion"];

                //We inject the view into the region.
                region.Add(view);
                

            //    regionManager.RegisterViewWithRegion("WorkspaceRegion", typeof(AccountGrid));               
            }
            else throw new ModularityException();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        

    }
}