using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using GSIntegradora.Aplicacao.Dominio.Interfaces;
using GSIntegradora.Aplicacao.Infraestrutura.NHibernate.Mapeamentos;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;

namespace GSIntegradora.Aplicacao.Infraestrutura.NHibernate.Configuracao
{
	public class NHibernateHelper : INHibernateHelper
	{
		private static ISessionFactory _sessionFactory;
		private static readonly object SyncRoot = new object();

		public static ISessionFactory SessionFactory
		{
			get
			{
				if (_sessionFactory == null)
				{
					lock (SyncRoot)
					{
						if (_sessionFactory == null)
						{
							CriarSessionFactory();
						}
					}
					CriarSessionFactory();
				}
				return _sessionFactory;
			}
		}

		private static void CriarSessionFactory(bool criarSchema = false)
		{
			if (_sessionFactory != null) return;

			var cfg = ObterConfiguracao(criarSchema);

			cfg.SessionFactory()
				.GenerateStatistics();

			_sessionFactory = cfg.BuildSessionFactory();

		}

		public static Configuration ObterConfiguracao(bool criarSchema = false)
		{
			return Fluently
				.Configure()
				.Database(
					MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("GSIntegradora"))
					.ShowSql()
					.FormatSql()
				)
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserProfileMapeamento>())
				.CurrentSessionContext<WebSessionContext>()
				.BuildConfiguration();
		}

	}

}