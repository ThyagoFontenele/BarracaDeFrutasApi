namespace BarracaDonaMaria.Domain.Entities;

public class ItemPedido : IEntity
{
    public virtual int Id { get; set; }
    public virtual Pedido Pedido { get; set; }
    public virtual Produto Produto { get; set; }
    public virtual int Quantidade { get; set; }
    public virtual double Valor { get; set; }
}
