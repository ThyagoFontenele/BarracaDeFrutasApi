using BarracaDonaMaria.Domain.Entities;
using FluentNHibernate.Mapping;

namespace BarracaDonaMaria.Infrastructure.Mappings
{
    public class ClienteMap : ClassMap<Cliente>
    {
        public ClienteMap()
        {
            Id(c => c.Id);
            Map(c => c.Nome);
            Map(c => c.Endereco);
            Map(c => c.Telefone);
            Map(c => c.Cpf);
            Map(c => c.Saldo);
            Table("Cliente");
        }
    }
}
