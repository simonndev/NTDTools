using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtdTools.Presentation.Modularity
{
    public abstract class NtdModuleBase : IModule
    {
        public abstract void OnInitialized(IContainerProvider containerProvider);

        public abstract void RegisterTypes(IContainerRegistry containerRegistry);
    }
}
