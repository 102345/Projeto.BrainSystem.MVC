using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using BrainSystem.OS.BLL.Interface;
using BrainSystem.OS.BLL;

namespace BrainSystem.OS.MVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IClienteBusiness, ClienteBusiness>();
            container.RegisterType<IEnderecoBusiness, EnderecoBusiness>();
            container.RegisterType<IGrupoBusiness, GrupoBusiness>();
            container.RegisterType<IFuncionarioBusiness, FuncionarioBusiness>();
            container.RegisterType<IOrdemServicoBusiness, OrdemServicoBusiness>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}