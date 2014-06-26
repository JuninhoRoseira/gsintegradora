using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using GSIntegradora.Dominio.Entidades;

namespace GSIntegradora.Infraestrutura.NHibernate.Mapeamentos
{
	internal class UsuarioMapeamento : ClassMap<Usuario>
	{
		public UsuarioMapeamento()
		{
			this.Table("Usuario");

			this.Id(u => u.Codigo);

			this.Map(u => u.Nome).Not.Nullable();
			this.Map(u => u.Login).Not.Nullable();
			this.Map(u => u.Email).Not.Nullable();
			this.Map(u => u.Senha).Not.Nullable();
			this.Map(u => u.Ativo).Default("1");

		}

	}

}