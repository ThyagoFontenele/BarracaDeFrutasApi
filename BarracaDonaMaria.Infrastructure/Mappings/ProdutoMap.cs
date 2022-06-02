using BarracaDonaMaria.Domain.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarracaDonaMaria.Infrastructure.Mappings
{
    public class ProdutoMap : ClassMap<Produto>
    {
        public ProdutoMap()
        {
            Id(p => p.Id);
            Map(p => p.Nome);
            Map(p => p.Tipo);
            Map(p => p.Unidades);
            Map(p => p.Preco);
            Map(p => p.ImgUrl);
            Table("Produto");
        }
    }
}
