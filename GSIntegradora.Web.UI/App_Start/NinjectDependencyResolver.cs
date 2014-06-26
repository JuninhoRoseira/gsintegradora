using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using GSIntegradora.Infraestrutura.Ninject;
using Ninject;

namespace GSIntegradora.Web.UI
{
	public class NinjectDependencyResolver : IDependencyResolver
	{
		private readonly IKernel _kernel;

		public NinjectDependencyResolver()
		{
			var ioc = new IoC();

			ioc.Kernel.Load(Assembly.GetExecutingAssembly());
			ioc.Kernel.Unbind<ModelValidatorProvider>();

			_kernel = ioc.Kernel;
			
		}
		public object GetService(Type serviceType)
		{
			return _kernel.TryGet(serviceType);
		}
		public IEnumerable<object> GetServices(Type serviceType)
		{
			try
			{
				return _kernel.GetAll(serviceType);
			}
			catch (Exception)
			{
				return new List<object>();
			}
		}
	}
}