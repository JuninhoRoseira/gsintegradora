using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSIntegradora.Dominio.Interfaces;
using GSIntegradora.Dominio.Entidades;
using NHibernate;
using NHibernate.Linq;

namespace GSIntegradora.Infraestrutura.Contextos
{
	public class UsuarioContexto : IUsuarioContexto
	{
		private readonly ISession _sessao;

		public UsuarioContexto(ISession sessao)
		{
			_sessao = sessao;
		}

		public void AdicionaUsuario(Usuario usuario)
		{
			using (var transacao = _sessao.BeginTransaction())
			{
				_sessao.SaveOrUpdate(usuario);
				
				transacao.Commit();

			}

		}

		public Usuario ObtemUsuario(string login)
		{
			return _sessao.Query<Usuario>().FirstOrDefault(u => u.Login == login);
		}

		public Usuario ObtemUsuario(string login, string senha)
		{
			return _sessao.Query<Usuario>().FirstOrDefault(u => u.Login == login && u.Senha == senha);
		}

	}

}