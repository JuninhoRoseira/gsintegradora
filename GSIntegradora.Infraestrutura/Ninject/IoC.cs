using Ninject;
using System.Web.Security;

namespace GSIntegradora.Infraestrutura.Ninject
{
	public class IoC
	{
		public IoC()
		{
			Kernel = new StandardKernel(
				new ModuloNinjectDeDominio(),
				new ModuloNinjectDeAplicacao());
		}

		public IKernel Kernel { get; private set; }

	}

}