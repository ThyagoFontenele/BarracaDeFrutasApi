using BarracaDonaMaria.Domain.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarracaDonaMaria.Infrastructure.Mappings
{
    public class PedidoMap : ClassMap<Pedido>
    {
        public PedidoMap()
        {
            Id(p => p.Id);
            Map(p => p.Data);
            Map(p => p.Total);
            Map(p => p.Finalizado);
            References(p => p.Cliente, "clienteId").Cascade.None();
            HasMany(p => p.Items).KeyColumn("pedidoId").Inverse().Cascade.All();
            Table("Pedido");
        }
    }
}
