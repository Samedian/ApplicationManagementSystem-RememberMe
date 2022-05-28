using ApplicantManagementSystemBAL;
using ApplicantManagementSystemDAL;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ApplicationManagementSystem
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IAccountBAl, AccountBAl>();
            container.RegisterType<IAccountDAL, AccountDAL>();
            container.RegisterType<IModelConvertor, ModelConvertor>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}