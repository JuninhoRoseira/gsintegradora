using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using GSIntegradora.Dominio.Entidades;

namespace GSIntegradora.Infraestrutura.Mapeamentos
{
	internal class UserProfileMapeamento : ClassMap<UserProfile>
	{
		public UserProfileMapeamento()
		{
			Table("Manifestacao");

			Id(m => m.Id, "Id");
			Map(m => m.Name, "Name").Not.Nullable();
		}
	}
}
