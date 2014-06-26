using Ninject;

namespace GSIntegradora.Aplicacao.Infraestrutura.Ninject
{
	public class IoC : StandardKernel
	{
		public IoC()
			: base(new ModuloNinjectDeDominio(),
				new ModuloNinjectDeAplicacao())
		{

		}
	}
}
