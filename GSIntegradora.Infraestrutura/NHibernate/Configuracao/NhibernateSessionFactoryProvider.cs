using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Ninject.Activation;

namespace GSIntegradora.Infraestrutura.NHibernate.Configuracao
{
	public class NhibernateSessionFactoryProvider : Provider<ISessionFactory>
	{
		protected override ISessionFactory CreateInstance(IContext context)
		{
			return NHibernateHelper.SessionFactory;
		}
	}
}
