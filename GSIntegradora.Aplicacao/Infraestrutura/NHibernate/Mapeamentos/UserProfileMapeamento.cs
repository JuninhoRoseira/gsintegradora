using FluentNHibernate.Mapping;
using GSIntegradora.Aplicacao.Dominio.Entidades;

namespace GSIntegradora.Aplicacao.Infraestrutura.NHibernate.Mapeamentos
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
