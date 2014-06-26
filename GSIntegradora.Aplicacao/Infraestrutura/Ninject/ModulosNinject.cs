using Ninject.Modules;

namespace GSIntegradora.Aplicacao.Infraestrutura.Ninject
{

	public class ModuloNinjectDeAplicacao : NinjectModule
    {
		public override void Load()
		{
			//Bind<IServicoDeAplicacaoDeProduto>().To<ServicoDeAplicacaoDeProduto>();

		}
	}

	public class ModuloNinjectDeDominio : NinjectModule
	{
		public override void Load()
		{
			//Bind<IServicoDeAplicacaoDeProduto>().To<ServicoDeAplicacaoDeProduto>();

		}
	}

}