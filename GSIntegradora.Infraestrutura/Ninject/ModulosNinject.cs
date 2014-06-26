using System.Web.Security;
using GSIntegradora.Aplicacao.Servicos;
using GSIntegradora.Dominio.Interfaces;
using GSIntegradora.Infraestrutura.Contextos;
using GSIntegradora.Infraestrutura.NHibernate.Configuracao;
using NHibernate;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;

namespace GSIntegradora.Infraestrutura.Ninject
{

	public class ModuloNinjectDeAplicacao : NinjectModule
    {
		public override void Load()
		{
			Bind<ISessionFactory>().ToProvider<NhibernateSessionFactoryProvider>().InSingletonScope();
			Bind<ISession>().ToMethod(context => context.Kernel.Get<ISessionFactory>().OpenSession()).InRequestScope();
			Bind<IFormsAuthenticationService>().To<FormsAuthenticationService>();
			Bind<IMembershipService>().To<AccountMembershipService>();

			Bind<MembershipProvider>().To<GSIMembershipProvider>().WithConstructorArgument("usuarioContexto", new UsuarioContexto(NHibernateHelper.SessionFactory.OpenSession()));
			Bind<MembershipUser>().ToSelf().InRequestScope();

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