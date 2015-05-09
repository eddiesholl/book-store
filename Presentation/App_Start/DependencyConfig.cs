using Autofac;
using Autofac.Integration.Mvc;
using BookSales.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookSales.Presentation
{
	public class DependencyConfig
	{
		public static void RegisterDependencies()
		{
			var builder = new ContainerBuilder();

			// Detect and register all controllers
			builder.RegisterControllers(typeof(MvcApplication).Assembly);

			// Detect and register all services
			builder.RegisterAssemblyTypes(typeof(IService).Assembly)
			   .Where(t => t.GetInterfaces().Any(i => i.IsAssignableFrom(typeof(IService))))
			   .AsImplementedInterfaces();

			var container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
	}
}