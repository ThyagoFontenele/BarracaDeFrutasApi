using BarracaDonaMaria.Domain.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarracaDonaMaria.Infrastructure.Mappings
{
    public class ItemPedidoMap : ClassMap<ItemPedido>
    {
        public ItemPedidoMap()
        {
            Id(i => i.Id);
            References(i => i.Pedido, "pedidoId").Cascade.None();
            References(i => i.Produto, "produtoId").Cascade.None();
            Map(i => i.Quantidade).Column("quantidade");
            Map(i => i.Valor);
            Table("ItemPedido");
        }
    }
}
